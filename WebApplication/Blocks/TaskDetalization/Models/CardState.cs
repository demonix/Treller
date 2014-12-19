using System.ComponentModel;

namespace SKBKontur.Treller.WebApplication.Blocks.TaskDetalization.Models
{
    public enum CardState
    {
        [Description("����������")]
        Unknown,

        [Description("���������")]
        BeforeDevelop,

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
        Archived,
    }
}