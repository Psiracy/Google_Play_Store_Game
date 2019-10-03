using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EaseType
{
    In,
    Out,
    Both
}

public enum EaseCurve
{
    Sine,
    Quad,
    Cubic,
    Quart,
    Quint,
    Expo,
    Circ,
    Back,
    Elastic,
    Bounce
}

public class Easing
{
    float s = 1.70158f;

    public float Ease(float from, float change, float duration, EaseCurve curve, EaseType type, float step)
    {
        float normTime = step / duration;

        switch (curve)
        {
            #region sine
            case EaseCurve.Sine:
                switch (type)
                {
                    case EaseType.In:
                        return change * (1 - Mathf.Cos(normTime * (Mathf.PI / 2))) + from;
                    case EaseType.Out:
                        return change * Mathf.Sin(normTime * (Mathf.PI / 2)) + from;
                    case EaseType.Both:
                        return change * 0.5f * (1 - Mathf.Cos(Mathf.PI * normTime)) + from;
                    default:
                        break;
                }
                break;
            #endregion sine
            case EaseCurve.Quad:
                switch (type)
                {
                    case EaseType.In:

                    case EaseType.Out:

                    case EaseType.Both:

                    default:
                        break;
                }
                break;
            #region cubic
            case EaseCurve.Cubic:
                switch (type)
                {
                    case EaseType.In:
                        return change * Mathf.Pow(normTime, 3) + from;
                    case EaseType.Out:
                        return change * (Mathf.Pow(normTime - 1, 3) + 1) + from;
                    case EaseType.Both:
                        step /= duration * 0.5f;

                        if (step < 1)
                        {
                            return (change * 0.5f) * Mathf.Pow(step, 3) + from;
                        }

                        return (change * 0.5f) * (Mathf.Pow(step - 2, 3) + 2) + from;

                    default:
                        break;
                }
                break;
            #endregion cubic
            case EaseCurve.Quart:
                switch (type)
                {
                    case EaseType.In:

                    case EaseType.Out:

                    case EaseType.Both:

                    default:
                        break;
                }
                break;
            case EaseCurve.Quint:
                switch (type)
                {
                    case EaseType.In:

                    case EaseType.Out:

                    case EaseType.Both:

                    default:
                        break;
                }
                break;
            case EaseCurve.Expo:
                switch (type)
                {
                    case EaseType.In:

                    case EaseType.Out:

                    case EaseType.Both:

                    default:
                        break;
                }
                break;
            case EaseCurve.Circ:
                switch (type)
                {
                    case EaseType.In:

                    case EaseType.Out:

                    case EaseType.Both:

                    default:
                        break;
                }
                break;
            #region back
            case EaseCurve.Back:
                switch (type)
                {
                    case EaseType.In:
                        return change * (normTime) * normTime * ((s + 1) * normTime - s) + from;
                    case EaseType.Out:
                        step = (step / duration) - 1;
                        return change * ((step) * step * ((s + 1) * step + s) + 1) + from;                  
                    case EaseType.Both:
                        float s2 = s;
                        step /= duration;
                        step *= 2;

                        if ((step) < 1)
                        {
                            s2 *= (1.525f);
                            return change * 0.5f * (step * step * ((s2 + 1) * step - s2)) + from;
                        }

                        step -= 2;
                        s2 *= 1.525f;
                        return change * 0.5f * ((step) * step * ((s2 + 1) * step + s2) + 2) + from;

                    default:
                        break;
                }
                break;
            #endregion back
            #region elastic
            case EaseCurve.Elastic:
                float p = 0;
                float a = change;

                switch (type)
                {
                    case EaseType.In:
                        if (step == 0 || a == 0)
                        {
                            return from;
                        }

                        if (normTime == 1)
                        {
                            return from + change;
                        }

                        if (p == 0)
                        {
                            p = duration * 0.3f;
                        }

                        if (a < Mathf.Abs(change))
                        {
                            a = change;
                            s = p * 0.25f;
                        }
                        else
                        {
                            s = p / (2 * Mathf.PI) * Mathf.Asin(change / a);
                        }

                        return -(a * Mathf.Pow(2, 10 * (--normTime)) * Mathf.Sin((normTime * duration - s) * (2 * Mathf.PI) / p)) + from;


                    case EaseType.Out:
                        float step2 = step;
                        float from2 = from;
                        float change2 = change;
                        float duration2 = duration;

                        if (step2 == 0 || change2 == 0)
                        {
                            return from2;
                        }
                        step2 /= duration2;
                        if (step2 == 1)
                        {
                            return from2 + change;
                        }
                        if (p < 0.5f)
                        {
                            p = duration2 * 0.3f;
                        }
                        if (change2 < Mathf.Abs(change))
                        {
                            change2 = change;
                            s = p * 0.25f;
                        }
                        else
                        {
                            s = p / (2 * Mathf.PI) * Mathf.Asin(change / change2);
                        }
                        return change2 * Mathf.Pow(2, -10 * step2) * Mathf.Sin((step2 * duration2 - s) * (2 * Mathf.PI) / p) + change + from2;


                    case EaseType.Both:
                        if (step == 0 || a == 0)
                        {
                            return from;
                        }
                        step /= (duration * 0.5f);
                        if (step == 2)
                        {
                            return from + change;
                        }
                        if (p < 0.5f)
                        {
                            p = duration * (0.3f * 1.5f);
                        }
                        if (a < Mathf.Abs(change))
                        {
                            a = change;
                            s = p * 0.25f;
                        }
                        else
                        {
                            s = p / (2 * Mathf.PI) * Mathf.Asin(change / a);
                        }
                        if (step < 1)
                        {
                            return -0.5f * (a * Mathf.Pow(2, 10 * (--step)) * Mathf.Sin((step * duration - s) * (2 * Mathf.PI) / p)) + from;
                        }
                        return a * Mathf.Pow(2, -10 * (--step)) * Mathf.Sin((step * duration - s) * (2 * Mathf.PI) / p) * 0.5f + change + from;

                    default:
                        break;
                }
                break;
            #endregion elastic
            #region bounce
            case EaseCurve.Bounce:
                switch (type)
                {
                    case EaseType.In:
                        return change - Ease(0, change, duration, EaseCurve.Bounce, EaseType.Out, duration - step) + from;
                    case EaseType.Out:
                        step /= duration;

                        if (step < (1 / 2.75f))
                        {
                            return change * (7.5625f * step * step) + from;
                        }
                        else
                        if (step < (2 / 2.75f))
                        {
                            step -= (1.5f / 2.75f);
                            return change * (7.5625f * step * step + 0.75f) + from;
                        }
                        else
                        if (step < (2.5f / 2.75f))
                        {
                            step -= (2.25f / 2.75f);
                            return change * (7.5625f * step * step + 0.9375f) + from;
                        }
                        else
                        {
                            step -= (2.625f / 2.75f);
                            return change * (7.5625f * step * step + 0.984375f) + from;
                        }

                    case EaseType.Both:
                        if (step < duration * 0.5f)
                        {
                            return (Ease(0, change, duration, EaseCurve.Bounce, EaseType.In, step * 2) * 0.5f + from);
                        }

                        return (Ease(0, change, duration, EaseCurve.Bounce, EaseType.Out, step * 2 - duration) * 0.5f + change * 0.5f + from);

                    default:
                        break;
                }
                break;
            #endregion bounce
            default:
                break;
        }

        return 0;
    }
}
