using System.ComponentModel;

namespace SKBKontur.Treller.WebApplication.Implementation.TaskDetalization.BusinessObjects.Models
{
    public enum CardState
    {
        [Description("����������")]
        Unknown,

        [Description("��� �����")]
        BeforeDevelop,

        [Description("���������")]
        Analityc,

        [Description("����������� ���������")]
        AnalitycPresentation,

        [Description("����������")]
        Develop,

        [Description("�����")]
        Review,

        [Description("�����������")]
        Presentation,

        [Description("������������")]
        Testing,

        [Description("��� �����")]
        ReleaseWaiting,

        [Description("� ������")]
        Released,

        [Description("� ������")]
        Archived,
    }
}