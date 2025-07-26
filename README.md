Unity 2D 动作游戏 Demo
 
本项目是一个基于 Unity 的 2D 动作游戏 Demo，展示了玩家控制、敌人 AI、状态机、动画事件、物理检测和视差背景等核心功能。适合学习 Unity 2D 游戏开发的基础架构和最佳实践，适用于初学者和有一定经验的开发者。
功能特性

玩家控制：支持移动、跳跃、冲刺、滑墙、墙跳和连击攻击。
敌人 AI：基于状态机的敌人行为（待机、巡逻、追击、攻击）。
状态机架构：模块化的玩家和敌人状态机，便于扩展和维护。
动画事件：通过动画事件解耦逻辑与动画，实现精准攻击判定和状态切换。
物理检测：使用射线检测地面、墙体和攻击范围，确保交互准确。
视差背景：多层背景视差滚动，增强画面层次感。
Gizmos 可视化：在 Scene 视图中可视化碰撞和攻击范围，便于调试。

快速开始
环境要求

Unity 版本：2020.3 或更高
操作系统：Windows、macOS 或 Linux
依赖：.NET Framework 4.7.1

安装步骤

克隆项目：git clone https://github.com/YYchainsAw/2D-RPG-250.01.git


打开项目：
在 Unity Hub 中使用 Unity 2020.3 或更高版本打开项目文件夹。


运行游戏：
打开主场景（如 Assets/Scenes/Main.unity）。
点击 Unity 编辑器的“播放”按钮体验游戏。



项目结构
Assets/
├── Scripts/
│   ├── Player/                 # 玩家相关脚本（如 Player.cs, PlayerState.cs）
│   ├── Enemy/                  # 敌人相关脚本（如 Enemy.cs, EnemyState.cs）
│   ├── ParallaxBackground.cs   # 视差背景滚动脚本
│   └── Utilities/              # 通用工具脚本
├── Entity.cs                   # 实体基类，封装通用功能
├── Scenes/                     # 游戏场景（如 Main.unity）
└── ...                         # 动画、精灵等资源

核心脚本说明

Entity.cs：实体基类，处理移动、碰撞检测和角色翻转等通用功能。
Player.cs：玩家主脚本，管理输入、状态机和动画事件。
Enemy.cs：敌人主脚本，控制 AI 状态机和玩家检测。
PlayerState.cs / EnemyState.cs：状态基类，用于实现具体状态逻辑。
ParallaxBackground.cs：实现多层背景的视差滚动效果。
