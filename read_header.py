
import os

def read_file(path):
    encodings = ['utf-16', 'utf-8', 'cp1252']
    for enc in encodings:
        try:
            with open(path, 'r', encoding=enc) as f:
                content = f.readlines()
            print(f"Successfully read with {enc}")
            return content
        except Exception as e:
            continue
    print("Failed to read file with tested encodings")
    return []

path = r"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\Headers\XAPIOpt.h"
lines = read_file(path)

for line in lines:
    if "FocusPos" in line:
        print(line.strip())
