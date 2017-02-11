// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using DotNetwork.Oldscape.Network.Protocol.Codec.Handshake;
using System.Net;

namespace DotNetwork.Oldscape.Network
{

    /// <summary>
    /// The network starter.
    /// </summary>
    sealed class NetworkBootstrap
    {
        /// <summary>
        /// Starts the network.
        /// </summary>
        public static void StartNetwork()
        {
            var boss = new MultithreadEventLoopGroup(1);
            var worker = new MultithreadEventLoopGroup();
            var bootstrap = new ServerBootstrap();
            bootstrap.Group(boss, worker);
            bootstrap.Channel<TcpServerSocketChannel>();
            bootstrap.ChildHandler(new ActionChannelInitializer<ISocketChannel>((ch) =>
            {
                IChannelPipeline pipeline = ch.Pipeline;
                pipeline.AddLast("encoder", new HandshakeEncoder());
                pipeline.AddLast("decoder", new HandshakeDecoder());
                pipeline.AddLast("handler", new NetworkHandler(ch));

            }));
            bootstrap.ChildOption(ChannelOption.TcpNodelay, true);
            bootstrap.BindAsync(IPAddress.Parse(Constants.SERVER_IP), Constants.SERVER_PORT);
        }
    }
}
