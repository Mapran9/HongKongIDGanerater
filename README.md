# HongKongIDGanerater
ganerate Hong Kong ID for testing something...  
Run at : https://dotnetfiddle.net/  
C#.NET8  
# Rules
1 Length:  
Must be exactly 8 characters long.  
2 Structure:  
The 1st character must be an uppercase English letter (A–Z), excluding 'W'.  
The next 6 characters (positions 2–7) must be digits (0–9).  
The last character (8th) is a check digit (0–9) used for validation.  
3 Character rules:  
Valid format: [A-Z (excluding W)] + 6 digits + 1 digit  
Example: A1234567  
4 Check digit validation (Mod 11):  
The ID is valid only if the weighted sum of all characters is divisible by 11.  
Weighting works as follows (from left to right):8, 7, 6, 5, 4, 3, 2, 1  
The letter prefix is converted to a number:A=1, B=2, ..., Z=26 (skip W)  
Multiply each character by its corresponding weight.  
Add all the weighted values.  
If the total modulo 11 (total % 11) equals 0 = Valid  
5 Invalid cases:  
If the length ≠ 8  
If the first character is not a capital letter or is 'W'  
If any of the characters in positions 2–8 are not digits  
If the calculated total is not divisible by 11  
