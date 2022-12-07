# UExtension

**UExtension** is a basic type extension library for .Net and Unity projects. It integrates a large number of commonly used, efficient and convenient extension methods, which helps to greatly improve development efficiency.

![topLanguage](https://img.shields.io/github/languages/top/ls9512/UExtension)
![size](https://img.shields.io/github/languages/code-size/ls9512/UExtension)
![issue](https://img.shields.io/github/issues/ls9512/UExtension)
![license](https://img.shields.io/github/license/ls9512/UExtension)
![last](https://img.shields.io/github/last-commit/ls9512/UExtension)
[![996.icu](https://img.shields.io/badge/link-996.icu-red.svg)](https://996.icu)

[[中文文档]](README_CN.md)

> 🐧 Official QQ group: [1070645638](https://jq.qq.com/?_wv=1027&k=ezkLnUln)

***

<!-- vscode-markdown-toc -->
* 1. [Feature](#Feature)
* 2. [Environment](#Environment)
* 3. [File](#File)
* 4. [How to use](#Howtouse)
* 5. [Notice](#Notice)

<!-- vscode-markdown-toc-config
	numbering=true
	autoSave=true
	/vscode-markdown-toc-config -->
<!-- /vscode-markdown-toc -->

***

##  1. <a name='Feature'></a>Feature
* Provide a large number of .Net native types and extension methods of Unity native types.
* Optimize the user experience of native types and improve development efficiency.
* No other dependent libraries.
* The API is concise and easy to use, and the name is clear.
* Take into account ease of use and high performance as much as possible, and avoid GC as much as possible.
* Most of the code files can be used independently, you can only use the required parts or delete the unnecessary parts as needed.

***

##  2. <a name='Environment'></a>Environment
![Unity: 2019.4](https://img.shields.io/badge/Unity-2019.4+-blue) 
![.NET 4.x](https://img.shields.io/badge/.NET-4.x-blue) 

***

##  3. <a name='File'></a>File
└─&nbsp;Extension
&nbsp;&nbsp;├─&nbsp;CSharp
&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;Script
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Collection
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ArrayExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/ArrayExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ArrayListExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/ArrayListExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[HashSetExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/HashSetExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ICollectionExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/ICollectionExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[IDictionaryExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/IDictionaryExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[IEnumerableExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/IEnumerableExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[IListExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/IListExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[ListExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Collection/ListExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Compare
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ComparerUtil.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Compare/ComparerUtil.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ComparisonUtil.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Compare/ComparisonUtil.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[IComparableExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Compare/IComparableExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;IO
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[FileInfoExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/IO/FileInfoExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[StreamExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/IO/StreamExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Net
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[SocketExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Net/SocketExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Reflection
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[AssemblyExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Reflection/AssemblyExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MemberInfoExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Reflection/MemberInfoExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MethodInfoExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Reflection/MethodInfoExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[TypeExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Reflection/TypeExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Util
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ActionExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/ActionExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ChainStyleExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/ChainStyleExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[FuncExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/FuncExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ObjectExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/ObjectExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[StringBuilderExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/StringBuilderExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[TExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/TExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[ValidateExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Util/ValidateExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;Value
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[BooleanExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/BooleanExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[ByteExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/ByteExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[CharExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/CharExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[DateTimeExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/DateTimeExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[DateTimeOffsetExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/DateTimeOffsetExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[DecimalExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/DecimalExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[DoubleExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/DoubleExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[EnumExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/EnumExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[FloatExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/FloatExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[IntExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/IntExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[LongExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/LongExtension.cs)
&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;[StringExtension.cs](https://github.com/ls9512/UExtension/blob/master/CSharp/Script/Value/StringExtension.cs)
&nbsp;&nbsp;└─&nbsp;Unity
&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Editor
&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;Script
&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[GenericMenuExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Editor/Script/GenericMenuExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;[SerializedPropertyExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Editor/Script/SerializedPropertyExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;Runtime
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;Script
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Class
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[AnimationCurveExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Class/AnimationCurveExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[GradientExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Class/GradientExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Component
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[AnimationExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/AnimationExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[AnimatorExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/AnimatorExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[CameraExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/CameraExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[LineRendererExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/LineRendererExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MeshFilterExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/MeshFilterExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[NavMeshAgentExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/NavMeshAgentExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ParticleSystemExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/ParticleSystemExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[PolygonCollider2DExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/PolygonCollider2DExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RendererExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/RendererExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[Rigidbody2DExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/Rigidbody2DExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RigidbodyExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/RigidbodyExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[SpriteRendererExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/SpriteRendererExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[TilemapExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Component/TilemapExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Core
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[BehaviourExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Core/BehaviourExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ComponentExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Core/ComponentExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[GameObjectExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Core/GameObjectExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MonoBehaviourExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Core/MonoBehaviourExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[TransformExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Core/TransformExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[UnityObjectExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Core/UnityObjectExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Object
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MaterialExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Object/MaterialExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ShaderExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Object/ShaderExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[Texture2DExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Object/Texture2DExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;Struct
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[BoundsExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/BoundsExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[BoundsIntExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/BoundsIntExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ColorExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/ColorExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[LayerMaskExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/LayerMaskExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MatrixExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/MatrixExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[MinMaxCurveExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/MinMaxCurveExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[QuaternionExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/QuaternionExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RangeExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/RangeExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[Ray2DExtensions.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/Ray2DExtensions.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RayExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/RayExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RectExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/RectExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RectIntExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/RectIntExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[RectOffsetExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/RectOffsetExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[ResolutionExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/ResolutionExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[Vector2Extension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/Vector2Extension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[Vector2IntExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/Vector2IntExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[Vector3Extension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/Vector3Extension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;├─&nbsp;[Vector3IntExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/Vector3IntExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;│&nbsp;&nbsp;└─&nbsp;[Vector4Extension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/Struct/Vector4Extension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;UI
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[ButtonExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/UI/ButtonExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├─&nbsp;[InputFiledExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/UI/InputFiledExtension.cs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└─&nbsp;[RectTransformExtension.cs](https://github.com/ls9512/UExtension/blob/master/Unity/Runtime/Script/UI/RectTransformExtension.cs)

***

##  4. <a name='Howtouse'></a>How to use
Copy the entire project folder into the `UnityProject/Assets/Plugins/` directory.

***

##  5. <a name='Notice'></a>Notice
* The method of the warehouse is implemented by the author himself or collected from the Internet and other open source projects during the development process for many years, and has been accumulated so far.
* This project is only recommended for learning and use. The author cannot guarantee the functional reliability, result accuracy and actual performance of all interfaces. Although the author has actually used this project in multiple commercial projects, please fully test it yourself if you need it for commercial use.
* All interfaces have tried to improve the readability of signatures, and the implementation logic of most interfaces is very simple. In addition, the characteristics of the warehouse may lead to frequent updates, and the author has limited energy, so no interface documents are provided.
* Due to the author's own needs, the project contains a large number of replacement implementation interfaces that overlap with Linq, and will be split separately as an optional part later.
* If you find problems in use, improve suggestions, or want to add new functions, you are welcome to submit a PR.