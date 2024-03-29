using MessagePack;
using MessagePack.Formatters;
using ObsStrawket.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ObsStrawket.DataTypes {

  // https://github.com/obsproject/obs-websocket/blob/5f8a0122bdd0146fdb33968f6bdf6ab624851e7a/src/utils/Obs_ArrayHelper.cpp#L335
  // https://github.com/obsproject/obs-studio/blob/master/docs/sphinx/reference-outputs.rst
  /// <summary>
  /// Outputs allow the ability to output the currently rendering audio/video.<br />
  /// Streaming and recording are two common examples of outputs, but not the only
  /// types of outputs.<br />Outputs can receive the raw data or receive encoded data.
  /// </summary>
  [MessagePackObject]
  public class Output {
    /// <summary>
    /// Name of the output.
    /// </summary>
    [Key("outputName")]
    public string Name { get; set; } = "";

    /// <summary>
    /// Example: <c>ffmpeg_muxer</c>, <c>virtualcam_output</c>
    /// </summary>
    [Key("outputKind")]
    public string Kind { get; set; } = "";

    /// <summary>
    /// Video width.
    /// </summary>
    [Key("outputWidth")]
    public int Width { get; set; }

    /// <summary>
    /// Video height.
    /// </summary>
    [Key("outputHeight")]
    public int Height { get; set; }

    /// <summary>
    /// Whether it is recorded or streamed.
    /// </summary>
    [Key("outputActive")]
    public bool Active { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Key("outputFlags")]
    [MessagePackFormatter(typeof(OutputFlagsMapFormatter))]
    public OutputFlags Flags { get; set; }
  }

  // https://github.com/obsproject/obs-websocket/blob/7893ae5caafecddb9589fe90719809b4f528f03e/src/utils/Obs_ArrayHelper.cpp#L339
  /// <summary>
  /// Output capability flags
  /// </summary>
  [Flags]
  [MessagePackFormatter(typeof(EnumAsStringFormatter<OutputFlags>))]
  public enum OutputFlags {
    /// <summary>
    /// Output has video.
    /// </summary>
    [EnumMember(Value = "OBS_OUTPUT_VIDEO")]
    Video = 1 << 0,

    /// <summary>
    /// Output has audio.
    /// </summary>
    [EnumMember(Value = "OBS_OUTPUT_AUDIO")]
    Audio = 1 << 1,

    /// <summary>
    /// Output is encoded.
    /// </summary>
    [EnumMember(Value = "OBS_OUTPUT_ENCODED")]
    Encoded = 1 << 2,

    /// <summary>
    /// Output requires a service object.
    /// </summary>
    [EnumMember(Value = "OBS_OUTPUT_SERVICE")]
    Service = 1 << 3,

    /// <summary>
    /// Output supports multiple audio tracks.
    /// </summary>
    [EnumMember(Value = "OBS_OUTPUT_MULTI_TRACK")]
    MultiTrack = 1 << 4,

    /// <summary>
    /// Output can be paused.
    /// </summary>
    [EnumMember(Value = "OBS_OUTPUT_CAN_PAUSE")]
    CanPause = 1 << 5,
  }

  // https://github.com/obsproject/obs-websocket/blob/5f8a0122bdd0146fdb33968f6bdf6ab624851e7a/src/utils/Obs_ArrayHelper.cpp#L87
  /// <summary>
  /// Represents OBS scene.
  /// </summary>
  [MessagePackObject]
  public class Scene {
    /// <summary>
    /// Scene name.
    /// </summary>
    [Key("sceneName")]
    public string Name { get; set; } = "";

    /// <summary>
    /// Scene index.
    /// </summary>
    [Key("sceneIndex")]
    public int Index { get; set; }
  }

  //https://github.com/obsproject/obs-websocket/blob/d5077fca03a47144f7c0eb81b5d3278186e31d59/src/utils/Obs_VolumeMeter.cpp#L66
  [MessagePackObject]
  public class InputVolumeMeter {
    [Key("inputName")]
    public string Name { get; set; } = "";
    [Key("inputUuid")]
    public string Uuid { get; set; } = "";
    [Key("inputLevelsMul")]
    public float[][] Level { get; set; } = Array.Empty<float[]>();

  }

  //https://github.com/obsproject/obs-websocket/blob/5f8a0122bdd0146fdb33968f6bdf6ab624851e7a/src/utils/Obs_ArrayHelper.cpp#L179
  /// <summary>
  /// OBS input, e.g. scene items.
  /// </summary>
  [MessagePackObject]
  public class Input {
    /// <summary>
    /// Input name.
    /// </summary>
    [Key("inputName")]
    public string Name { get; set; } = "";

    /// <summary>
    /// Input kind. e.g. <c>color_source_v3</c>
    /// </summary>
    [Key("inputKind")]
    public string Kind { get; set; } = "";

    /// <summary>
    /// Input kind without version. e.g. <c>color_source</c>
    /// </summary>
    [Key("unversionedInputKind")]
    public string UnversionedKind { get; set; } = "";
  }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

  //https://github.com/obsproject/obs-websocket/blob/265899f76f88a5be74747308fff3d35347ce43c5/src/utils/Obs_ArrayHelper.cpp#L142
  /// <summary>
  /// Represents reindexed scene item.
  /// </summary>
  [MessagePackObject]
  public class BasicSceneItem {
    [Key("sceneItemId")]
    public int Id { get; set; }

    [Key("sceneItemIndex")]
    public int Index { get; set; }
  }

  //https://github.com/obsproject/obs-websocket/blob/265899f76f88a5be74747308fff3d35347ce43c5/src/utils/Obs_ArrayHelper.cpp#L142
  /// <summary>
  /// Represents scene item.
  /// </summary>
  [MessagePackObject]
  public class SceneItem : BasicSceneItem {
    [Key("sceneItemEnabled")]
    public bool? Enabled { get; set; }

    [Key("sceneItemLocked")]
    public bool? Locked { get; set; }

    [Key("sceneItemTransform")]
    public Dictionary<string, object>? Transform { get; set; }

    [Key("sceneItemBlendMode")]
    public BlendingType? BlendMode { get; set; }

    [Key("sourceName")]
    public string? SourceName { get; set; }

    [Key("sourceType")]
    public SourceType? SourceType { get; set; }

    [Key("inputKind")]
    public string? InputKind { get; set; }

    [Key("isGroup")]
    public bool? IsGroup { get; set; }
  }

  // https://github.com/obsproject/obs-websocket/blob/265899f76f88a5be74747308fff3d35347ce43c5/src/utils/Obs_ArrayHelper.cpp#L306-L307
  /// <summary>
  /// Represents source filter.
  /// </summary>
  [MessagePackObject]
  public class SourceFilter {
    [Key("filterName")]
    public string Name { get; set; } = "";

    [Key("filterIndex")]
    public int Index { get; set; }

    [Key("filterKind")]
    public string Kind { get; set; } = "";

    [Key("filterEnabled")]
    public bool Enabled { get; set; }

    [Key("filterSettings")]
    public Dictionary<string, object?> Settings { get; set; } = new();
  }

  // https://github.com/obsproject/obs-websocket/blob/265899f76f88a5be74747308fff3d35347ce43c5/src/utils/Obs_ArrayHelper.cpp#L273
  /// <summary>
  /// Listed scene transition.
  /// </summary>
  [MessagePackObject]
  public class AvailableTransition {
    /// <summary>
    /// Name of the transition.
    /// </summary>
    [Key("transitionName")]
    public string Name { get; set; } = "";

    /// <summary>
    /// Kind of the transition.
    /// </summary>
    [Key("transitionKind")]
    public string Kind { get; set; } = "";

    /// <summary>
    /// Whether the transition uses a fixed (unconfigurable) duration.
    /// </summary>
    [Key("transitionFixed")]
    public bool Fixed { get; set; }

    /// <summary>
    /// Whether the transition supports being configured.
    /// </summary>
    [Key("transitionConfigurable")]
    public bool Configurable { get; set; }
  }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
