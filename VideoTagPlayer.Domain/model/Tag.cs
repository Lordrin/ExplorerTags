using System.ComponentModel;

namespace VideoTagPlayer.Domain.model
{
    public enum Tag
    {
        music,
        finish,
        [Description("2D")]
        twoD,
        [Description("3D")]
        threeD,
        full,
        MMV,
        HMV,
        PMV,
    }
}
