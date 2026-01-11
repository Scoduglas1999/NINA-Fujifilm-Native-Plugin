using System;

namespace NINA.Plugins.Fujifilm.Devices.LiveView;

/// <summary>
/// Represents a single frame from the live view stream.
/// Contains JPEG data from the camera.
/// </summary>
public sealed class LiveViewFrame
{
    /// <summary>
    /// Creates a new live view frame.
    /// </summary>
    public LiveViewFrame(byte[] jpegData, int width, int height, int format, long timestamp)
    {
        JpegData = jpegData ?? throw new ArgumentNullException(nameof(jpegData));
        Width = width;
        Height = height;
        Format = format;
        Timestamp = timestamp;
        CapturedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// The raw JPEG data from the camera.
    /// </summary>
    public byte[] JpegData { get; }

    /// <summary>
    /// Width of the frame in pixels.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Height of the frame in pixels.
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// SDK image format code.
    /// </summary>
    public int Format { get; }

    /// <summary>
    /// SDK timestamp value.
    /// </summary>
    public long Timestamp { get; }

    /// <summary>
    /// UTC time when this frame was captured.
    /// </summary>
    public DateTime CapturedAt { get; }

    /// <summary>
    /// Size of the JPEG data in bytes.
    /// </summary>
    public int DataSize => JpegData.Length;
}
