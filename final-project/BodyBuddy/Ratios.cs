public static class Ratios
{
    public static float? FallibleRatio(float? a, float? b, Func<float, float, float> ratioFunc)
    {
        // Return null if missing a value, otherwise calculate and return the ratio.
        bool incomplete = !(a.HasValue && b.HasValue);
        // These aren't null if the condition is false.
        return incomplete ? null : ratioFunc(a!.Value, b!.Value);
    }

    public static float? GetBmi(float? weight, float? height)
    {
        const int WEIGHT_MULTIPLIER = 703;
        return FallibleRatio(weight, height, (w, h) => w * WEIGHT_MULTIPLIER / (h * h));
    }

    public static float? GetBri(float? height, float? waist)
    {
        return FallibleRatio(height, waist, (h, w) => 0); // TODO: Implement BRI calculation.
    }
}
