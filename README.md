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

![installer](http://i.imgur.com/fbW8p8v.png)

# Installer Prerequisites
- Microsoft .NET Framework [4.6.1](https://www.microsoft.com/en-us/download/details.aspx?id=49981) (x86 and x64)

# Creating a Packet for Encoding
Adding and encoding game packets haven't been easier. With the use of reflection, a repository is always created once the server runs for the encoded game client packets. Create a class and extend the parent class PacketEncoder. Each packet must also be used with the respective context. View the example code below for how a packet encoder should look like in DotNetwork.
```csharp
    /// <summary>
    /// The interface packet encoder.
    /// </summary>
    sealed class InterfaceEncoder : PacketEncoder<InterfaceContext>
    {

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        public InterfaceEncoder() : base(66, PacketType.FIXED) { }

        /// <summary>
        /// Encodes the packet.
        /// </summary>
        /// <param name="context"></param>
        public override void Encode(InterfaceContext context)
        {
            builder.Put(DataType.SHORT, context.GetInterfaceId());
            builder.Put(DataType.INT, DataOrder.MIDDLE, context.GetRootId() << 16 | context.GetChildId());
            builder.Put(DataType.BYTE, DataTransformation.SUBTRACT, context.IsOverlay() ? 1 : 0);
        }

    }
```

# Writing a Packet to the Client
Writing a packet to the client is easy to do. After creating a packet, use the context that is used with the encoder to activate the event listener to encode the buffer data to the client.
```csharp
            if (channel.Registered)
                GamePacketListener.SendGamePacket(channel, context);
```

```csharp
player.SendPacket(new InterFaceContext());
```

# Decoding a Packet from the Client
Decoding packets work in a very similar way in terms of how packet encoders/decoders are created to read the information. Here is an example class of a packet decoder.
```csharp
    /// <summary>
    /// The action button decoder.
    /// </summary>
    sealed class ActionButtonDecoder : PacketDecoder
    {

        /// <summary>
        /// Decodes the packet.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="id"></param>
        /// <param name="reader"></param>
        public void Decode(Player player, int id, PacketReader reader)
        {
            int interfaceId = (int)reader.GetUnsigned(DataType.SHORT);
            int buttonId = (int)reader.GetUnsigned(DataType.SHORT);
            int slot = (int)reader.GetUnsigned(DataType.SHORT);
            int item = (int)reader.GetUnsigned(DataType.SHORT);
            if (slot == 65535)
                slot = 0;
            if (item == 65535)
                item = 0;
            InterfaceListenerRepository.GetInterfaceListener(interfaceId).Execute(player, interfaceId, buttonId, slot, item);
        }

        /// <summary>
        /// Gets the packet ids.
        /// </summary>
        /// <returns></returns>
        public int[] GetPacketIds()
        {
            return new int[] { 255, 149, 194, 148, 0, 245, 159 };
        }

    }
```

# Acknowledgements
- [OpenRSS](https://github.com/Impulser/OpenRSS) by [Impulser](https://github.com/Impulser).
- [ISAAC](http://www.burtleburtle.net/bob/rand/isaacafa.html) cryptography random number generator.
