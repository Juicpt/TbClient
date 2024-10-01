namespace TbClient.Api.GetThreads.Entities;

public class ForumT
{
    public long Fid { get; set; }
    public string Fname  { get; set; }= "";
    public string Category  { get; set; }= "";
    public string Subcategory { get; set; } = "";
    public int MemberNum { get; set; }
    public int PostNum  { get; set; }
    public int ThreadNum  { get; set; }
    public bool HasBaWu  { get; set; }
    public bool HasRule  { get; set; }

    public static ForumT FromTbData(FrsPageResIdl.Types.DataRes dataRes)
    {
        var forumInfo = dataRes.Forum;
        return new ForumT()
        {
            Fid = forumInfo.Id,
            Fname = forumInfo.Name,
            Category = forumInfo.FirstClass,
            Subcategory = forumInfo.SecondClass,
            MemberNum = forumInfo.MemberNum,
            PostNum = forumInfo.PostNum,
            ThreadNum = forumInfo.ThreadNum,
            HasBaWu = forumInfo.Managers.Count != 0,
            HasRule = dataRes.ForumRule.HasForumRule == 1,
        };
    }

    public override string ToString()
    {
        return
            $"{nameof(Fid)}: {Fid}, {nameof(Fname)}: {Fname}, {nameof(Category)}: {Category}, {nameof(Subcategory)}: {Subcategory}, {nameof(MemberNum)}: {MemberNum}, {nameof(PostNum)}: {PostNum}, {nameof(ThreadNum)}: {ThreadNum}, {nameof(HasBaWu)}: {HasBaWu}, {nameof(HasRule)}: {HasRule}";
    }
}