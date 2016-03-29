using System.ComponentModel;

namespace SKBKontur.Treller.WebApplication.Implementation.Activities.BusinessObjects
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