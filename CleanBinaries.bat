FOR /D %%p IN ("**\bin\") DO rmdir "%%p" /s /q
FOR /D %%p IN ("**\obj\") DO rmdir "%%p" /s /q
pause