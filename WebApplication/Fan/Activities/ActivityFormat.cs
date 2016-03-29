using System.ComponentModel;

namespace SKBKontur.Treller.WebApplication.Fan.Activities
{
    public enum ActivityFormat
    {
        [Description("�������")]
        Game,
        
        [Description("������-���������")]
        PresentationWithDiscussion,

        [Description("���������")]
        Discussion,

        [Description("������ + �������")]
        Presentation,

        [Description("������������ �����������")]
        NotSelectedYet,
        
        [Description("")]
        Empty
    }
}