# FTD2XXHelper

通过.net standard实现的可跨平台使用<br />

在<a href="https://ftdichip.com/software-examples/code-examples/csharp-examples/">官方</a> FTD2XX_NET v1.2版本基础上进行修改<br />

根据不同的平台,Windows下使用kernel32.dll,LoadLibrary. Linux下使用libdl.so,UnixLoadLibrary. 动态加载FTD2XX.DLL或libftd2xx.so<br />

Install-Package FTD2XXHelper -Version 1.2.0

