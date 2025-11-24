
import os
import re

def search_file(path):
    print(f"Searching {path}...")
    try:
        with open(path, 'r', encoding='utf-8', errors='ignore') as f:
            lines = f.readlines()
        
        for line in lines:
            if "API_CODE_CapFocusPos" in line:
                print(f"FOUND: {line.strip()}")
            if "API_CODE_SetFocusPos" in line:
                print(f"FOUND: {line.strip()}")
            if "API_CODE_GetFocusPos" in line:
                print(f"FOUND: {line.strip()}")
            
            if "typedef struct _SDK_FOCUS_POS_CAP" in line:
                print("FOUND STRUCT START")
                idx = lines.index(line)
                for i in range(idx, min(idx + 15, len(lines))):
                    print(lines[i].strip())
                    if "}" in lines[i]:
                        break

    except Exception as e:
        print(f"Error reading file: {e}")

search_file(r"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\Headers\XAPIOpt.h")
