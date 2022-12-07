# UExtension

**UExtension** 是一个用于 .Net 和 Unity 项目的基础类型扩展函数库，集成大量常用、高效、便捷的扩展方法，有助于大幅度提高开发效率。

![topLanguage](https://img.shields.io/github/languages/top/ls9512/UExtension)
![size](https://img.shields.io/github/languages/code-size/ls9512/UExtension)
![issue](https://img.shields.io/github/issues/ls9512/UExtension)
![license](https://img.shields.io/github/license/ls9512/UExtension)
![last](https://img.shields.io/github/last-commit/ls9512/UExtension)
[![996.icu](https://img.shields.io/badge/link-996.icu-red.svg)](https://996.icu)

[[English Documents Available]](README.md)

> 🐧 官方交流QQ群：[1070645638](https://jq.qq.com/?_wv=1027&k=ezkLnUln)

***

<!-- vscode-markdown-toc -->
* 1. [特性](#)
* 2. [环境](#-1)
* 3. [文件](#-1)
* 4. [使用](#-1)
* 5. [注意](#-1)

<!-- vscode-markdown-toc-config
	numbering=true
	autoSave=true
	/vscode-markdown-toc-config -->
<!-- /vscode-markdown-toc -->

***

##  1. <a name=''></a>特性
* 提供大量 .Net 原生类型以及 Unity 原生类型的扩展方法。
* 优化原生类型的使用体验，提高开发效率。
* 无其他依赖库。
* API 简洁易用，见名知意。
* 尽可能兼顾易用性和高性能，尽可能避免GC。
* 大部分代码文件可独立使用，可按需只使用需要的部分或者删除不需要的部分。

***

##  2. <a name='-1'></a>环境
![Unity: 2019.4](https://img.shields.io/badge/Unity-2019.4+-blue) 
![.NET 4.x](https://img.shields.io/badge/.NET-4.x-blue) 

***

##  3. <a name='-1'></a>文件
└─&nbsp;Extension&nbsp;&nbsp;
&nbsp;&nbsp;├─&nbsp;CSharp&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;Script&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Collection&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ArrayExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/ArrayExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ArrayListExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/ArrayListExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[HashSetExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/HashSetExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ICollectionExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/ICollectionExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[IDictionaryExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/IDictionaryExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[IEnumerableExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/IEnumerableExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[IListExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/IListExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[ListExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/ListExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Compare&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ComparerUtil.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Compare/ComparerUtil.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ComparisonUtil.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Compare/ComparisonUtil.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[IComparableExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Compare/IComparableExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;IO&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[FileInfoExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/IO/FileInfoExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[StreamExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/IO/StreamExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Net&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[SocketExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Net/SocketExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Reflection&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[AssemblyExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Reflection/AssemblyExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MemberInfoExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Reflection/MemberInfoExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MethodInfoExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Reflection/MethodInfoExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[TypeExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Reflection/TypeExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Util&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ActionExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/ActionExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ChainStyleExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/ChainStyleExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[FuncExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/FuncExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ObjectExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/ObjectExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[StringBuilderExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/StringBuilderExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[TExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/TExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[ValidateExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/ValidateExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;Value&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[BooleanExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/BooleanExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[ByteExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/ByteExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[CharExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/CharExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[DateTimeExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/DateTimeExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[DateTimeOffsetExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/DateTimeOffsetExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[DecimalExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/DecimalExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[DoubleExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/DoubleExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[EnumExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/EnumExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[FloatExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/FloatExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[IntExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/IntExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[LongExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/LongExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;[StringExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/StringExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;├─&nbsp;Unity&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;Editor&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;Script&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[GenericMenuExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Editor/Script/GenericMenuExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;[SerializedPropertyExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Editor/Script/SerializedPropertyExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;Runtime&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;Script&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Class&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[AnimationCurveExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Class/AnimationCurveExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[GradientExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Class/GradientExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Component&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[AnimationExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/AnimationExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[AnimatorExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/AnimatorExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[CameraExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/CameraExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[LineRendererExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/LineRendererExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MeshFilterExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/MeshFilterExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[NavMeshAgentExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/NavMeshAgentExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ParticleSystemExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/ParticleSystemExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[PolygonCollider2DExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/PolygonCollider2DExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RendererExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/RendererExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[Rigidbody2DExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/Rigidbody2DExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RigidbodyExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/RigidbodyExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[SpriteRendererExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/SpriteRendererExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[TilemapExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/TilemapExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Core&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[BehaviourExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Core/BehaviourExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ComponentExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Core/ComponentExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[GameObjectExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Core/GameObjectExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MonoBehaviourExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Core/MonoBehaviourExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[TransformExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Core/TransformExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[UnityObjectExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Core/UnityObjectExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Object&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MaterialExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Object/MaterialExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ShaderExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Object/ShaderExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[Texture2DExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Object/Texture2DExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Struct&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[BoundsExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/BoundsExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[BoundsIntExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/BoundsIntExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ColorExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/ColorExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[LayerMaskExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/LayerMaskExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MatrixExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/MatrixExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MinMaxCurveExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/MinMaxCurveExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[QuaternionExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/QuaternionExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RangeExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/RangeExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[Ray2DExtensions.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/Ray2DExtensions.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RayExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/RayExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RectExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/RectExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RectIntExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/RectIntExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RectOffsetExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/RectOffsetExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ResolutionExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/ResolutionExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[Vector2Extension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/Vector2Extension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[Vector2IntExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/Vector2IntExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[Vector3Extension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/Vector3Extension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[Vector3IntExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/Vector3IntExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[Vector4Extension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/Vector4Extension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;UI&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[ButtonExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/UI/ButtonExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[InputFiledExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/UI/InputFiledExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;[RectTransformExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/UI/RectTransformExtension.cs)&nbsp;&nbsp;
&nbsp;&nbsp;├─&nbsp;[.git](https://github.com/ls9512/UExtension/blob/master/.git)&nbsp;&nbsp;
&nbsp;&nbsp;└─&nbsp;[package.json](https://github.com/ls9512/UExtension/blob/master/package.json)&nbsp;&nbsp;


***

##  4. <a name='-1'></a>使用
将项目文件夹整个放入 `UnityProject/Assets/Plugins/` 目录下即可。

***

##  5. <a name='-1'></a>注意
* 仓库的方法为作者多年开发过程中自行实现或搜集于互联网和其他开源项目，积累至今。
* 该项目仅推荐学习使用，作者不能确保所有接口的功能可靠性，结果准确性以及实际性能，虽然作者已经将该项目实际运用于多个商业项目中，但如需商用仍然请自行充分测试。
* 所有接口已经尽可能提高签名的可读性，且大部分接口的实现逻辑非常简单，再加上仓库特性可能导致频繁更新，作者精力有限，所以不提供接口文档。
* 因作者本人需要，项目中包含大量与 Linq 重合的替换实现接口，后续会单独拆分出来作为可选部分。
* 如在使用中发现问题，改进建议，或者想增加新的功能，欢迎提交PR。