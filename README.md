# FuckMeeting+

FuckMeeting+（下文简称为FM+）是 [FuckTencentMeeting](github.com/Yoroion/FuckTencentMeeting) 的重构升级版，遵循 Windows 11 风格的 Fluent Design，是基于 .NET 6.0 的 WPF 应用

## 📷 截图展示

![浅色模式](./screenshots/Light.png)

![浅色模式](./screenshots/Dark.png)

## ✨ 特性

- 腾讯会议定时自动入会
- 用户配置保存
- 基于 Timer 调度
- Fluent Design 设计 / Mica 云母视觉效果
- 浅色 / 深色模式
- 搭载 .NET Desktop 运行时，无需另行安装
- MVVM 架构

## ⚒️ 使用教程

1. 填写**合法的**腾讯会议安装路径，如 `E:\Tencent Room\WeMeet\wemeetapp.exe`
2. 填写腾讯会议的启动时间，单位为**秒**。这个数值取决于您的计算机配置
3. 使用 *Snipaste* 等软件获取需要点击的坐标，并在 FM+ 中填写。共计**两个**坐标，代表着将要点击的**加入会议**按钮
4. 填写您的会议号码
5. 填写**符合格式的**预定时间，月/日/时/分，如 `08/31/09/00`
6. 单击**保存配置**
7. 尽情享用，开始摸鱼！

## ⚠️ 注意事项

- 点击 ⌈开始摸鱼⌋ 按钮后，如果您想要取消任务，点击左上角的 × 关闭即可，FM+ 不会进驻您的系统后台
- 请务必保证填写的路径和预定时间符合格式
- FM+ 检查当前时间是否到达预定时间的周期为 30 秒

## ❤️ 鸣谢

- [Microsoft.Toolkit.MVVM]([CommunityToolkit/WindowsCommunityToolkit: The Windows Community Toolkit is a collection of helpers, extensions, and custom controls. It simplifies and demonstrates common developer tasks building UWP and .NET apps for Windows 10. The toolkit is part of the .NET Foundation. (github.com)](https://github.com/CommunityToolkit/WindowsCommunityToolkit))

- [H.InputSimulater]([HavenDV/H.InputSimulator: Allows you to simulate global mouse and keyboard events. (github.com)](https://github.com/HavenDV/H.InputSimulator))

- [WPFUI]([lepoco/wpfui: A simple way to make your application written in WPF keep up with modern design trends. Library changes the base elements like Page, ToggleButton or List, and also includes additional controls like Navigation, NumberBox, Dialog or Snackbar. (github.com)](https://github.com/lepoco/wpfui))

- ReSharper

以及所有支持本项目的朋友，你们的 Star 将帮助 FM+ 这个小项目走得更远

## 🔨 开发环境要求

如果您想要自行修改 FM+ 或者为 FM+ 贡献代码，您需要安装 Visual Studio 2022 及 .NET SDK 6.0

## ⚖️ 协议

FM+ 基于 AGPL v3 协议开源，您需要保留原作者的版权信息，查看 [协议条款](./LICENSE.txt)