
import os

def search_file(path):
    print(f"Searching {path}...")
    try:
        with open(path, 'r', encoding='utf-8', errors='ignore') as f:
            lines = f.readlines()
        
        found = False
        for line in lines:
            if "API_CODE_CapFocusPos" in line or "API_CODE_SetFocusPos" in line or "API_CODE_GetFocusPos" in line:
                print(line.strip())
                found = True
            if "typedef struct _SDK_FOCUS_POS_CAP" in line:
                print("Found struct definition start")
                found = True
                # Print next few lines to get the struct members
                idx = lines.index(line)
                for i in range(idx, min(idx + 15, len(lines))):
                    print(lines[i].strip())
        
        if not found:
            print("No matches found.")

    except Exception as e:
        print(f"Error reading file: {e}")

search_file(r"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\Headers\XAPIOpt.h")
