using System.ComponentModel;

namespace VideoTagPlayer.Domain.model
{
    public enum Tag
    {
        music = 1,
        finish = 2,
        [Description("2D")]
        twoD = 3,
        [Description("3D")]
        threeD = 4,
        full = 5,
        MMV = 6,
        HMV = 7,
        PMV = 8, 
    }
}
