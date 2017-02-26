![logo-open-source](https://github.com/jordanabrahambaws/DotNetwork/blob/master/logo.ico?raw=true)

# DotNetwork (.NET)
[![Join the chat at https://gitter.im/DotNetwork/Lobby](https://badges.gitter.im/DotNetwork/Lobby.svg)](https://gitter.im/DotNetwork/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

# About
A fast and lightweight C# emulation game network for the RuneTek engine.

# Aim
The aim for DotNetwork is to provide an open source game network built in C#. The backbone of the network is developed using the asynchronous event-driven network application framework from Netty. DotNetwork hopes to provide a easy-to-use and rapid code environment for anyone (even those inexperienced) to be able to build on top of this. This network is built for the java version of the [RuneTek](http://runescape.wikia.com/wiki/RuneTek) game engine.

# Dependencies
DotNetwork is developed using a number of packages using the [Nuget](https://www.nuget.org/) package manager.
- [DotNetty](https://github.com/Azure/DotNetty) by [Azure](https://github.com/Azure/).
- [IKVM](https://www.nuget.org/packages/IKVM/)
- [SharpZipLab](https://icsharpcode.github.io/SharpZipLib/) for [GZIP](https://en.wikipedia.org/wiki/Gzip) and [BZIP2](https://en.wikipedia.org/wiki/Bzip2) decompression/compression.
- [Preconditions.NET](https://www.nuget.org/packages/Preconditions.NET/)

# Installing DotNetwork
For easy installment of DotNetwork on your system, use the provided [Setup](https://github.com/jordanabrahambaws/DotNetwork/blob/master/Installer/setup.exe) executable. These builds will be updated to the installer every master branch push, and be mindful that (for now), DotNetwork is not in the release stage. But you can install and test out the application for yourself without the hassle of downloading/forking this repository.

# Acknowledgements
- [OpenRSS](https://github.com/Impulser/OpenRSS) by [Impulser](https://github.com/Impulser).
- [ISAAC](http://www.burtleburtle.net/bob/rand/isaacafa.html) cryptography random number generator.
