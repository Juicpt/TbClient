// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: LayoutFactory.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from LayoutFactory.proto</summary>
public static partial class LayoutFactoryReflection {

  #region Descriptor
  /// <summary>File descriptor for LayoutFactory.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static LayoutFactoryReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChNMYXlvdXRGYWN0b3J5LnByb3RvIrUBCg1MYXlvdXRGYWN0b3J5Eg4KBmxh",
          "eW91dBgBIAEoCRInCgRmZWVkGAIgASgLMhkuTGF5b3V0RmFjdG9yeS5GZWVk",
          "TGF5b3V0GmsKCkZlZWRMYXlvdXQSNwoNYnVzaW5lc3NfaW5mbxgFIAMoCzIg",
          "LkxheW91dEZhY3RvcnkuRmVlZExheW91dC5GZWVkS1YaJAoGRmVlZEtWEgsK",
          "A2tleRgBIAEoCRINCgV2YWx1ZRgCIAEoCWIGcHJvdG8z"));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::LayoutFactory), global::LayoutFactory.Parser, new[]{ "Layout", "Feed" }, null, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::LayoutFactory.Types.FeedLayout), global::LayoutFactory.Types.FeedLayout.Parser, new[]{ "BusinessInfo" }, null, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::LayoutFactory.Types.FeedLayout.Types.FeedKV), global::LayoutFactory.Types.FeedLayout.Types.FeedKV.Parser, new[]{ "Key", "Value" }, null, null, null, null)})})
        }));
  }
  #endregion

}
#region Messages
[global::System.SerializableAttribute]
[global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
public sealed partial class LayoutFactory : pb::IMessage<LayoutFactory>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<LayoutFactory> _parser = new pb::MessageParser<LayoutFactory>(() => new LayoutFactory());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<LayoutFactory> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::LayoutFactoryReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public LayoutFactory() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public LayoutFactory(LayoutFactory other) : this() {
    layout_ = other.layout_;
    feed_ = other.feed_ != null ? other.feed_.Clone() : null;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public LayoutFactory Clone() {
    return new LayoutFactory(this);
  }

  /// <summary>Field number for the "layout" field.</summary>
  public const int LayoutFieldNumber = 1;
  private string layout_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Layout {
    get { return layout_; }
    set {
      layout_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "feed" field.</summary>
  public const int FeedFieldNumber = 2;
  private global::LayoutFactory.Types.FeedLayout feed_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public global::LayoutFactory.Types.FeedLayout Feed {
    get { return feed_; }
    set {
      feed_ = value;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as LayoutFactory);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(LayoutFactory other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Layout != other.Layout) return false;
    if (!object.Equals(Feed, other.Feed)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (Layout.Length != 0) hash ^= Layout.GetHashCode();
    if (feed_ != null) hash ^= Feed.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Layout.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Layout);
    }
    if (feed_ != null) {
      output.WriteRawTag(18);
      output.WriteMessage(Feed);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Layout.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Layout);
    }
    if (feed_ != null) {
      output.WriteRawTag(18);
      output.WriteMessage(Feed);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    if (Layout.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Layout);
    }
    if (feed_ != null) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(Feed);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(LayoutFactory other) {
    if (other == null) {
      return;
    }
    if (other.Layout.Length != 0) {
      Layout = other.Layout;
    }
    if (other.feed_ != null) {
      if (feed_ == null) {
        Feed = new global::LayoutFactory.Types.FeedLayout();
      }
      Feed.MergeFrom(other.Feed);
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Layout = input.ReadString();
          break;
        }
        case 18: {
          if (feed_ == null) {
            Feed = new global::LayoutFactory.Types.FeedLayout();
          }
          input.ReadMessage(Feed);
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          Layout = input.ReadString();
          break;
        }
        case 18: {
          if (feed_ == null) {
            Feed = new global::LayoutFactory.Types.FeedLayout();
          }
          input.ReadMessage(Feed);
          break;
        }
      }
    }
  }
  #endif

  #region Nested types
  /// <summary>Container for nested types declared in the LayoutFactory message type.</summary>
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static partial class Types {
    [global::System.SerializableAttribute]
    [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
    public sealed partial class FeedLayout : pb::IMessage<FeedLayout>
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        , pb::IBufferMessage
    #endif
    {
      private static readonly pb::MessageParser<FeedLayout> _parser = new pb::MessageParser<FeedLayout>(() => new FeedLayout());
      private pb::UnknownFieldSet _unknownFields;
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public static pb::MessageParser<FeedLayout> Parser { get { return _parser; } }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public static pbr::MessageDescriptor Descriptor {
        get { return global::LayoutFactory.Descriptor.NestedTypes[0]; }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      pbr::MessageDescriptor pb::IMessage.Descriptor {
        get { return Descriptor; }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public FeedLayout() {
        OnConstruction();
      }

      partial void OnConstruction();

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public FeedLayout(FeedLayout other) : this() {
        businessInfo_ = other.businessInfo_.Clone();
        _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public FeedLayout Clone() {
        return new FeedLayout(this);
      }

      /// <summary>Field number for the "business_info" field.</summary>
      public const int BusinessInfoFieldNumber = 5;
      private static readonly pb::FieldCodec<global::LayoutFactory.Types.FeedLayout.Types.FeedKV> _repeated_businessInfo_codec
          = pb::FieldCodec.ForMessage(42, global::LayoutFactory.Types.FeedLayout.Types.FeedKV.Parser);
      private readonly pbc::RepeatedField<global::LayoutFactory.Types.FeedLayout.Types.FeedKV> businessInfo_ = new pbc::RepeatedField<global::LayoutFactory.Types.FeedLayout.Types.FeedKV>();
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public pbc::RepeatedField<global::LayoutFactory.Types.FeedLayout.Types.FeedKV> BusinessInfo {
        get { return businessInfo_; }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public override bool Equals(object other) {
        return Equals(other as FeedLayout);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public bool Equals(FeedLayout other) {
        if (ReferenceEquals(other, null)) {
          return false;
        }
        if (ReferenceEquals(other, this)) {
          return true;
        }
        if(!businessInfo_.Equals(other.businessInfo_)) return false;
        return Equals(_unknownFields, other._unknownFields);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public override int GetHashCode() {
        int hash = 1;
        hash ^= businessInfo_.GetHashCode();
        if (_unknownFields != null) {
          hash ^= _unknownFields.GetHashCode();
        }
        return hash;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public override string ToString() {
        return pb::JsonFormatter.ToDiagnosticString(this);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public void WriteTo(pb::CodedOutputStream output) {
      #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        output.WriteRawMessage(this);
      #else
        businessInfo_.WriteTo(output, _repeated_businessInfo_codec);
        if (_unknownFields != null) {
          _unknownFields.WriteTo(output);
        }
      #endif
      }

      #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
        businessInfo_.WriteTo(ref output, _repeated_businessInfo_codec);
        if (_unknownFields != null) {
          _unknownFields.WriteTo(ref output);
        }
      }
      #endif

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public int CalculateSize() {
        int size = 0;
        size += businessInfo_.CalculateSize(_repeated_businessInfo_codec);
        if (_unknownFields != null) {
          size += _unknownFields.CalculateSize();
        }
        return size;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public void MergeFrom(FeedLayout other) {
        if (other == null) {
          return;
        }
        businessInfo_.Add(other.businessInfo_);
        _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public void MergeFrom(pb::CodedInputStream input) {
      #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        input.ReadRawMessage(this);
      #else
        uint tag;
        while ((tag = input.ReadTag()) != 0) {
        if ((tag & 7) == 4) {
          // Abort on any end group tag.
          return;
        }
        switch(tag) {
            default:
              _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
              break;
            case 42: {
              businessInfo_.AddEntriesFrom(input, _repeated_businessInfo_codec);
              break;
            }
          }
        }
      #endif
      }

      #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
        uint tag;
        while ((tag = input.ReadTag()) != 0) {
        if ((tag & 7) == 4) {
          // Abort on any end group tag.
          return;
        }
        switch(tag) {
            default:
              _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
              break;
            case 42: {
              businessInfo_.AddEntriesFrom(ref input, _repeated_businessInfo_codec);
              break;
            }
          }
        }
      }
      #endif

      #region Nested types
      /// <summary>Container for nested types declared in the FeedLayout message type.</summary>
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
      public static partial class Types {
        [global::System.SerializableAttribute]
        [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
        public sealed partial class FeedKV : pb::IMessage<FeedKV>
        #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            , pb::IBufferMessage
        #endif
        {
          private static readonly pb::MessageParser<FeedKV> _parser = new pb::MessageParser<FeedKV>(() => new FeedKV());
          private pb::UnknownFieldSet _unknownFields;
          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public static pb::MessageParser<FeedKV> Parser { get { return _parser; } }

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public static pbr::MessageDescriptor Descriptor {
            get { return global::LayoutFactory.Types.FeedLayout.Descriptor.NestedTypes[0]; }
          }

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          pbr::MessageDescriptor pb::IMessage.Descriptor {
            get { return Descriptor; }
          }

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public FeedKV() {
            OnConstruction();
          }

          partial void OnConstruction();

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public FeedKV(FeedKV other) : this() {
            key_ = other.key_;
            value_ = other.value_;
            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
          }

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public FeedKV Clone() {
            return new FeedKV(this);
          }

          /// <summary>Field number for the "key" field.</summary>
          public const int KeyFieldNumber = 1;
          private string key_ = "";
          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public string Key {
            get { return key_; }
            set {
              key_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
            }
          }

          /// <summary>Field number for the "value" field.</summary>
          public const int ValueFieldNumber = 2;
          private string value_ = "";
          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public string Value {
            get { return value_; }
            set {
              value_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
            }
          }

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public override bool Equals(object other) {
            return Equals(other as FeedKV);
          }

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public bool Equals(FeedKV other) {
            if (ReferenceEquals(other, null)) {
              return false;
            }
            if (ReferenceEquals(other, this)) {
              return true;
            }
            if (Key != other.Key) return false;
            if (Value != other.Value) return false;
            return Equals(_unknownFields, other._unknownFields);
          }

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public override int GetHashCode() {
            int hash = 1;
            if (Key.Length != 0) hash ^= Key.GetHashCode();
            if (Value.Length != 0) hash ^= Value.GetHashCode();
            if (_unknownFields != null) {
              hash ^= _unknownFields.GetHashCode();
            }
            return hash;
          }

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public override string ToString() {
            return pb::JsonFormatter.ToDiagnosticString(this);
          }

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public void WriteTo(pb::CodedOutputStream output) {
          #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            output.WriteRawMessage(this);
          #else
            if (Key.Length != 0) {
              output.WriteRawTag(10);
              output.WriteString(Key);
            }
            if (Value.Length != 0) {
              output.WriteRawTag(18);
              output.WriteString(Value);
            }
            if (_unknownFields != null) {
              _unknownFields.WriteTo(output);
            }
          #endif
          }

          #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
            if (Key.Length != 0) {
              output.WriteRawTag(10);
              output.WriteString(Key);
            }
            if (Value.Length != 0) {
              output.WriteRawTag(18);
              output.WriteString(Value);
            }
            if (_unknownFields != null) {
              _unknownFields.WriteTo(ref output);
            }
          }
          #endif

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public int CalculateSize() {
            int size = 0;
            if (Key.Length != 0) {
              size += 1 + pb::CodedOutputStream.ComputeStringSize(Key);
            }
            if (Value.Length != 0) {
              size += 1 + pb::CodedOutputStream.ComputeStringSize(Value);
            }
            if (_unknownFields != null) {
              size += _unknownFields.CalculateSize();
            }
            return size;
          }

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public void MergeFrom(FeedKV other) {
            if (other == null) {
              return;
            }
            if (other.Key.Length != 0) {
              Key = other.Key;
            }
            if (other.Value.Length != 0) {
              Value = other.Value;
            }
            _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
          }

          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          public void MergeFrom(pb::CodedInputStream input) {
          #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            input.ReadRawMessage(this);
          #else
            uint tag;
            while ((tag = input.ReadTag()) != 0) {
            if ((tag & 7) == 4) {
              // Abort on any end group tag.
              return;
            }
            switch(tag) {
                default:
                  _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                  break;
                case 10: {
                  Key = input.ReadString();
                  break;
                }
                case 18: {
                  Value = input.ReadString();
                  break;
                }
              }
            }
          #endif
          }

          #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
          [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
          [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
          void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
            uint tag;
            while ((tag = input.ReadTag()) != 0) {
            if ((tag & 7) == 4) {
              // Abort on any end group tag.
              return;
            }
            switch(tag) {
                default:
                  _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                  break;
                case 10: {
                  Key = input.ReadString();
                  break;
                }
                case 18: {
                  Value = input.ReadString();
                  break;
                }
              }
            }
          }
          #endif

        }

      }
      #endregion

    }

  }
  #endregion

}

#endregion


#endregion Designer generated code
