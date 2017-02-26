# ![logo-open-source](https://github.com/jordanabrahambaws/DotNetwork/blob/master/logo.ico?raw=true) DotNetwork (.NET)
[![Join the chat at https://gitter.im/DotNetwork/Lobby](https://badges.gitter.im/DotNetwork/Lobby.svg)](https://gitter.im/DotNetwork/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

# About
A fast and lightweight C# emulation game network for the RuneTek engine.

# Aim
The aim for DotNetwork is to provide an open source game network built in C#. The backbone of the network is developed using the asynchronous event-driven network application framework from Netty. DotNetwork hopes to provide a easy-to-use and rapid code environment for anyone (even those inexperienced) to be able to build on top of this. This network is built for the java version of the [RuneTek](http://runescape.wikia.com/wiki/RuneTek) game engine.

![runetek](http://i.imgur.com/IeMKTqD.png)

# Dependencies
DotNetwork is developed using a number of packages using the [Nuget](https://www.nuget.org/) package manager.
- [DotNetty](https://github.com/Azure/DotNetty) by [Azure](https://github.com/Azure/).
- [IKVM](https://www.nuget.org/packages/IKVM/)
- [SharpZipLab](https://icsharpcode.github.io/SharpZipLib/) for [GZIP](https://en.wikipedia.org/wiki/Gzip) and [BZIP2](https://en.wikipedia.org/wiki/Bzip2) decompression/compression.
- [Preconditions.NET](https://www.nuget.org/packages/Preconditions.NET/)

# Installing DotNetwork
You can easily install DotNetwork on your system by using the provided [Setup](https://github.com/jordanabrahambaws/DotNetwork/blob/master/Installer/setup.msi) windows installer application. This installer will be updated with every master branch push. Be mindful that (for now), DotNetwork is not in the release stage and problems/bugs can be expected. Use this instaler to test out the application for yourself without the hassle of downloading/forking this repository.

# Installer Prerequisites
- Microsoft .NET Framework [4.6.1](https://www.microsoft.com/en-us/download/details.aspx?id=49981) (x86 and x64)

# Acknowledgements
- [OpenRSS](https://github.com/Impulser/OpenRSS) by [Impulser](https://github.com/Impulser).
- [ISAAC](http://www.burtleburtle.net/bob/rand/isaacafa.html) cryptography random number generator.
