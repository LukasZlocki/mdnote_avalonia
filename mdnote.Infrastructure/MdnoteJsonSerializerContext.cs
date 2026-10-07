using System.Text.Json.Serialization;
using mdnote.Domain;

namespace mdnote.Infrastructure;

[JsonSerializable(typeof(WindowPosition))]
[JsonSerializable(typeof(string))]
internal partial class MdnoteJsonSerializerContext : JsonSerializerContext;