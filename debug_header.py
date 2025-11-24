
import os

def debug_file(path):
    if not os.path.exists(path):
        print(f"File not found: {path}")
        return

    try:
        with open(path, 'rb') as f:
            header = f.read(100)
        print(f"First 100 bytes of {os.path.basename(path)}: {header}")
        
        # Try to decode with replacement
        print(f"Decoded (utf-16): {header.decode('utf-16', errors='replace')}")
        print(f"Decoded (utf-8): {header.decode('utf-8', errors='replace')}")
    except Exception as e:
        print(f"Error reading file: {e}")

debug_file(r"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\Headers\XAPIOpt.h")
debug_file(r"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\Headers\XAPI.h")
