
import os

def search_file(path, output_path):
    try:
        with open(path, 'r', encoding='utf-8', errors='ignore') as f:
            lines = f.readlines()
        
        with open(output_path, 'w', encoding='utf-8') as out:
            for line in lines:
                if "API_CODE_CapFocusPos" in line:
                    out.write(f"FOUND: {line.strip()}\n")
                if "API_CODE_SetFocusPos" in line:
                    out.write(f"FOUND: {line.strip()}\n")
                if "API_CODE_GetFocusPos" in line:
                    out.write(f"FOUND: {line.strip()}\n")
                
                if "typedef struct _SDK_FOCUS_POS_CAP" in line:
                    out.write("FOUND STRUCT START\n")
                    idx = lines.index(line)
                    for i in range(idx, min(idx + 15, len(lines))):
                        out.write(lines[i].strip() + "\n")
                        if "}" in lines[i]:
                            break

    except Exception as e:
        with open(output_path, 'w') as out:
            out.write(f"Error: {e}")

search_file(r"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\Headers\XAPIOpt.h", r"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\extracted_constants.txt")
