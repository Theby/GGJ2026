using System;

[Flags]
public enum MaskPartAttribute
{
    None = 0,
    Elegant = 1,
    Feral = 2,
    Familiar = 4,
    Sad = 8,
    Happy = 16,
    Neutral = 32,
}