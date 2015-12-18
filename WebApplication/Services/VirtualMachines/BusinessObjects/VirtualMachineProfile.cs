using System.ComponentModel;

namespace SKBKontur.Treller.WebApplication.Services.VirtualMachines.BusinessObjects
{
    public enum VirtualMachineProfile
    {
        [Description("�������� ������")]
        Stand,

        [Description("�������������� � ���� �����")]
        Ci,

        [Description("�������������� �����")]
        FunctionalCi,

        [Description("3 ����")]
        ThreeNode,

        [Description("���� ������ 3 �����")]
        BuildServer,
    }
}