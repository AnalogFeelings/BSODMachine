# The NT API BSOD Machine
NT API BSOD Machine is a C# program to BSOD the system. This takes advantage of 2 undocumented NT API method that working together, raises a BSOD with an error code.

This does NOT require administrator permissions to BSOD the system, this function has existed since atleast Windows XP (AFAIK).

***

-`RtlAdjustPriviledge(int Priviledge, bool EnablePriviledge, bool IsThreadPriviledge, out bool PreviousVal)` - Changes the priviledge in the current process or thread.

-`NtRaiseHardError(uint ErrorStatus, uint NumOfParams, uint UnicodeStrParamMask, IntPtr Params, uint ValidResponseOption, out uint Response)` - Sends a HARDERROR_MSG LPC message to CSRSS.exe. Using the error status `0xC0000420` causes it to trigger a BSOD with STATUS_ASSERTION_FAILURE.

# ***I AM NOT RESPONSIBLE FOR ANY DAMAGES DONE BY THE MISUSE OF THIS PROGRAM.***
