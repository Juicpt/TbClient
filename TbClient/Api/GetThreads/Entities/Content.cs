using TbClient.Api.Entities.Contents;

namespace TbClient.Api.GetThreads.Entities;

public class Content
{
    public List<FragText> Texts { get; set; } = [];
    public List<FragEmoji> Emojis { get; set; } = [];
    public List<FragImage> Images { get; set; } = [];
    public List<FragAt> Ats { get; set; } = [];
    public List<FragLink> Links { get; set; } = [];
    public List<FragTiebaPlus> TiebaPluses { get; set; } = [];
    public FragVideo? Video { get; set; }
    public FragVoice? Voice { get; set; }
    public List<IFrag> Frags { get; set; } = [];

    public static Content FromTbData(ThreadInfo.Types.OriginThreadInfo threadInfo)
    {
        var texts = new List<FragText>();
        var emojis = new List<FragEmoji>();
        var images = new List<FragImage>();
        var ats = new List<FragAt>();
        var links = new List<FragLink>();
        var tiebaPluses = new List<FragTiebaPlus>();
        var frags = new List<IFrag>();
        FragVideo? video = null;
        FragVoice? voice = null;
        var typeHandlers = new Dictionary<uint[], Action<PbContent>>
        {
            {
                [0, 9, 18, 27], content =>
                {
                    var text = FragText.FromTbData(content);
                    texts.Add(text);
                    frags.Add(text);
                }
            },
            {
                [2, 11], content =>
                {
                    var emoji = FragEmoji.FromTbData(content);
                    emojis.Add(emoji);
                    frags.Add(emoji);
                }
            },
            {
                [3, 20], content =>
                {
                    var image = FragImage.FromTbData(content);
                    images.Add(image);
                    frags.Add(image);
                }
            },
            {
                [35, 36, 37], content =>
                {
                    var tiebaPlus = FragTiebaPlus.FromTbData(content);
                    tiebaPluses.Add(tiebaPlus);
                    frags.Add(tiebaPlus);
                }
            }
        };
        foreach (var content in threadInfo.Content)
        {
            var type = content.Type;
            // 处理字典中定义的类型
            var handled = typeHandlers
                .Where(kv => kv.Key.Contains(type))
                .Select(kv =>
                {
                    kv.Value(content);
                    return true;
                })
                .FirstOrDefault();

            if (handled) continue;

            switch (type)
            {
                case 4:
                {
                    var at = FragAt.FromTbData(content);
                    ats.Add(at);
                    frags.Add(at);
                    break;
                }
                case 1:
                {
                    var link = FragLink.FromTbData(content);
                    links.Add(link);
                    frags.Add(link);
                    break;
                }
                case 10:
                // video
                case 5:
                // outdated tiebaplus
                case 34:
                    // voice
                    break;
                default:
                    Console.WriteLine($"Unknown fragment type. type: {type}");
                    break;
            }
        }


        if (threadInfo?.VideoInfo != null)
        {
            video = FragVideo.FromTbData(threadInfo.VideoInfo);
        }

        if (threadInfo?.VoiceInfo is { Count: > 0 })
        {
            voice = FragVoice.FromTbData(threadInfo.VoiceInfo[0]);
        }

        return new Content()
        {
            Texts = texts,
            Emojis = emojis,
            Images = images,
            Ats = ats,
            Links = links,
            TiebaPluses = tiebaPluses,
            Frags = frags,
            Voice = voice,
            Video = video,
        };
    }

    public static Content FromTbData(ThreadInfo threadInfo)
    {
        var texts = new List<FragText>();
        var emojis = new List<FragEmoji>();
        var images = new List<FragImage>();
        var ats = new List<FragAt>();
        var links = new List<FragLink>();
        var tiebaPluses = new List<FragTiebaPlus>();
        var frags = new List<IFrag>();
        var video = new FragVideo();
        var voice = new FragVoice();
        var typeHandlers = new Dictionary<uint[], Action<PbContent>>
        {
            {
                [0, 9, 18, 27], content =>
                {
                    var text = FragText.FromTbData(content);
                    texts.Add(text);
                    frags.Add(text);
                }
            },
            {
                [2, 11], content =>
                {
                    var emoji = FragEmoji.FromTbData(content);
                    emojis.Add(emoji);
                    frags.Add(emoji);
                }
            },
            {
                [3, 20], content =>
                {
                    var image = FragImage.FromTbData(content);
                    images.Add(image);
                    frags.Add(image);
                }
            },
            {
                [35, 36, 37], content =>
                {
                    var tiebaPlus = FragTiebaPlus.FromTbData(content);
                    tiebaPluses.Add(tiebaPlus);
                    frags.Add(tiebaPlus);
                }
            }
        };
        foreach (var content in threadInfo.FirstPostContent)
        {
            var type = content.Type;
            // 处理字典中定义的类型
            var handled = typeHandlers
                .Where(kv => kv.Key.Contains(type))
                .Select(kv =>
                {
                    kv.Value(content);
                    return true;
                })
                .FirstOrDefault();

            if (handled) continue;
            switch (type)
            {
                case 4:
                {
                    var at = FragAt.FromTbData(content);
                    ats.Add(at);
                    frags.Add(at);
                    break;
                }
                case 1:
                {
                    var link = FragLink.FromTbData(content);
                    links.Add(link);
                    frags.Add(link);
                    break;
                }
                case 10:
                // video
                case 5:
                // outdated tiebaplus
                case 34:
                    // voice
                    break;
                default:
                {
                    Console.WriteLine($"Unknown fragment type. type: {type}");
                    break;
                }
            }
        }

        if (threadInfo?.VideoInfo != null)
        {
            video = FragVideo.FromTbData(threadInfo.VideoInfo);
        }

        if (threadInfo?.VoiceInfo is { Count: > 0 })
        {
            voice = FragVoice.FromTbData(threadInfo.VoiceInfo[0]);
        }

        return new Content()
        {
            Texts = texts,
            Emojis = emojis,
            Images = images,
            Ats = ats,
            Links = links,
            TiebaPluses = tiebaPluses,
            Frags = frags,
            Voice = voice,
            Video = video,
        };
    }
}