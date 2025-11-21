using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using NINA.Core.Enum;
using NINA.Equipment.Interfaces;
using NINA.Plugins.Fujifilm.Diagnostics;

namespace NINA.Plugins.Fujifilm.Devices;

public class FujiFocuserSdkAdapter : IFocuser, INotifyPropertyChanged
{
    private readonly FujiFocuser _focuser;
    private readonly FujifilmCameraDescriptor _descriptor;
    private readonly IFujifilmDiagnosticsService _diagnostics;
    private bool _connected;
    private int _position;
    private bool _isMoving;

    public event PropertyChangedEventHandler PropertyChanged;

    public FujiFocuserSdkAdapter(FujiFocuser focuser, FujifilmCameraDescriptor descriptor, IFujifilmDiagnosticsService diagnostics)
    {
        _focuser = focuser;
        _descriptor = descriptor;
        _diagnostics = diagnostics;
        Id = descriptor.DeviceId;
    }

    public bool Connected
    {
        get => _connected;
        set
        {
            if (value == _connected) return;
            if (value)
            {
                Connect(CancellationToken.None).GetAwaiter().GetResult();
            }
            else
            {
                Disconnect();
            }
        }
    }

    public string Name => _descriptor.DisplayName;
    public string Description => "Fujifilm Native Focuser";
    public string DriverInfo => "Fujifilm Native Driver";
    public string DriverVersion => "1.6";
    public int InterfaceVersion => 1;

    public bool Absolute => true;
    public bool IsMoving 
    { 
        get => _isMoving; 
        private set
        {
            if (_isMoving != value)
            {
                _isMoving = value;
                OnPropertyChanged();
            }
        }
    }

    public bool Link { get => Connected; set => Connected = value; }
    public int MaxIncrement => 1000;
    public int MaxStep => 10000;
    
    public int Position 
    { 
        get => _position; 
        private set
        {
            if (_position != value)
            {
                _position = value;
                OnPropertyChanged();
            }
        }
    }
    
    public double StepSize => 1.0;
    public bool TempComp { get => false; set { } }
    public bool TempCompAvailable => false;
    public double Temperature => 0;

    public string Id { get; }
    public string DisplayName => Name;
    public string Category => "Focuser";
    public IList<string> SupportedActions => Array.Empty<string>();
    public bool HasSetupDialog => false;

    public async Task<bool> Connect(CancellationToken token)
    {
        if (_connected) return true;
        try
        {
            _position = await _focuser.GetPositionAsync(token).ConfigureAwait(false);
            _connected = true;
            OnPropertyChanged(nameof(Connected));
            OnPropertyChanged(nameof(Link));
            _diagnostics.RecordEvent("FocuserAdapter", $"Connected to {_descriptor.DisplayName}");
            return true;
        }
        catch (Exception ex)
        {
            _diagnostics.RecordEvent("FocuserAdapter", $"Connection failed: {ex.Message}");
            throw;
        }
    }

    public void Disconnect()
    {
        if (!_connected) return;
        _focuser.DisposeAsync().GetAwaiter().GetResult();
        _connected = false;
        OnPropertyChanged(nameof(Connected));
        OnPropertyChanged(nameof(Link));
        _diagnostics.RecordEvent("FocuserAdapter", $"Disconnected {_descriptor.DisplayName}");
    }

    public void Halt()
    {
        // Not supported by SDK
    }

    public Task Move(int position)
    {
        return Move(position, CancellationToken.None, 30000);
    }

    public async Task Move(int position, CancellationToken token, int timeout)
    {
        if (!_connected) return;
        
        IsMoving = true;
        try
        {
            await _focuser.MoveAsync(position, token).ConfigureAwait(false);
            var newPos = await _focuser.GetPositionAsync(token).ConfigureAwait(false);
            Position = newPos;
        }
        catch (Exception ex)
        {
            _diagnostics.RecordEvent("FocuserAdapter", $"Move failed: {ex.Message}");
        }
        finally
        {
            IsMoving = false;
        }
    }

    public string Action(string action, string parameters) => string.Empty;
    public void SendCommandBlind(string command, bool raw) { }
    public bool SendCommandBool(string command, bool raw) => false;
    public string SendCommandString(string command, bool raw) => string.Empty;
    public void SetupDialog() { }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
