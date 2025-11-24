import os
import glob

headers_dir = r"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\Headers"
output_file = r"c:\Users\scdou\Documents\NINA.Fujifilm.Plugin\param_check_results.txt"

camera_headers = glob.glob(os.path.join(headers_dir, "*.h"))

results = {}

for header in camera_headers:
    basename = os.path.basename(header)
    if basename in ['XAPI.h', 'XAPIOpt.h', 'XAPI_MOV.H', 'XAPIOpt_MOV.H']:
        continue
    
    try:
        with open(header, 'r', encoding='utf-8', errors='ignore') as f:
            lines = f.readlines()
        
        params = {}
        for line in lines:
            if 'API_PARAM_CapFocusPos' in line and '=' in line:
                params['CapFocusPos'] = line.strip()
            if 'API_PARAM_SetFocusPos' in line and '=' in line:
                params['SetFocusPos'] = line.strip()
            if 'API_PARAM_GetFocusPos' in line and '=' in line:
                params['GetFocusPos'] = line.strip()
        
        if params:
            results[basename] = params
    except Exception as e:
        results[basename] = {'error': str(e)}

# Write results to file
with open(output_file, 'w', encoding='utf-8') as out:
    for camera, params in sorted(results.items()):
        out.write(f"\n{camera}:\n")
        for param_name, param_line in params.items():
            out.write(f"  {param_line}\n")

print(f"Results written to {output_file}")
