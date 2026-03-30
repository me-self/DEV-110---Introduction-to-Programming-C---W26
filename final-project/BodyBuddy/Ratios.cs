namespace BodyBuddy;

public static class Ratios
{
    private static double? FallibleRatio(double? a, double? b, Func<double, double, double> ratioFunc)
    {
        // Return null if missing a value, otherwise calculate and return the ratio.
        bool incomplete = !(a.HasValue && b.HasValue);

        // These aren't null if the condition is false.
        return incomplete ? null : ratioFunc(a!.Value, b!.Value);
    }

    public static double? GetBmi(double? weight, double? height)
    {
        const int WEIGHT_MULTIPLIER = 703;
        return FallibleRatio(weight, height, (w, h) => w * WEIGHT_MULTIPLIER / (h * h));
    }

    public static double? GetWhtr(double? height, double? waist)
    {
        return FallibleRatio(waist, height, (w, h) => w / h);
    }

    public static double? GetWhr(double? waist, double? hip)
    {
        return FallibleRatio(waist, hip, (w, h) => w / h);
    }

    public static double? GetApeIndex(double? height, double? wingspan)
    {
        return FallibleRatio(height, wingspan, (h, w) => w / h);
    }

    public static double? GetBri(double? height, double? waist)
    {
        return FallibleRatio(waist, height, (w, h) =>
        {
            // `h` and `w` aren't null so this is safe to cast.
            double whtr = (double)GetWhtr(h, w)!;
            double eccentricity = double.Sqrt(1 - double.Pow(whtr / Math.PI, 2));
            return 364.2f - (365.5f * eccentricity);
        });
    }
}
