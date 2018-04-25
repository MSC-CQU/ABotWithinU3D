# A Bot Within U3D

## 环境需求
Unity版本：2017.4.1f

Visual Studio版本：Visual Studio 2017

Windows版本：Windows 10 16299或更高

其它设备：Windows Mixed Reality Headset（真机测试通过）、HoloLens（模拟器运行通过）

## 简介
这是一个较为通用的Unity开发Mixed Reality应用时的Bot Framework组件，依赖HoloToolkit。支持实时语音捕捉输入，可更换任意固定指令或LUIS后端以满足不同需求场景。

## 使用到的技术
#### Bot形象
Unity Chan：将角色网格替换为其它角色可实现模型替换，由于要支持骨骼动画，暂不支持运行时替换人物形象。
#### MR开发包
HoloToolkit，正在向Mixed Reality Toolkit迁移，主要使用了Billboard、Controller、Cursor、Gaze、Focus等组件。
#### 语音捕捉及识别
Dictation Recognizer，实现实时捕获语音输入并转为文字，以作为LUIS的输入
#### 自然语言理解
LUIS




