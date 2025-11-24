import os

def extract_api_info(header_path, output_path):
    try:
        with open(header_path, 'r', encoding='utf-8', errors='ignore') as f:
            lines = f.readlines()
        
        with open(output_path, 'w', encoding='utf-8') as out:
            out.write("=== Sensitivity (ISO) APIs ===\n")
            for line in lines:
                if 'CapSensitivity' in line or 'SetSensitivity' in line or 'GetSensitivity' in line:
                    out.write(line.strip() + "\n")
            
            out.write("\n=== Media Record APIs ===\n")
            for line in lines:
                if 'MediaRecord' in line and 'API' in line:
                    out.write(line.strip() + "\n")
            
            out.write("\n=== Bulb/Shutter APIs ===\n")
            for line in lines:
                if 'ShutterSpeed' in line and 'API' in line:
                    out.write(line.strip() + "\n")
            
            out.write("\n=== Long Exposure NR APIs ===\n")
            for line in lines:
                if 'LongExposureNR' in line and 'API' in line:
                    out.write(line.strip() + "\n")

    except Exception as e:
        with open(output_path, 'w') as out:
            out.write(f"Error: {e}")

extract_api_info(
    r"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\Headers\X-T5.h",
    r"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\xt5_api_codes.txt"
)
print("Extracted API codes to xt5_api_codes.txt")
