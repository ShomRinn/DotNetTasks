using System;
using static System.Formats.Asn1.AsnWriter;

namespace AllergyTest
{
    /// <summary>
    /// Encapsulate the information about allergy test score and its analysis.
    /// </summary>
    public class Allergies
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Allergies"/> class with test score.
        /// </summary>
        /// <param name="score">The allergy test score.</param>
        /// <exception cref="ArgumentException">Thrown when score is less than zero.</exception>
        private readonly int scor;

        public Allergies(int score)
        {
                this.scor = score >= 0 ? score : throw new ArgumentException("Score cannot be negative.", nameof(score));
        }

        /// <summary>
        /// Determines on base on the allergy test score for the given person, whether or not they're allergic to a given allergen(s).
        /// </summary>
        /// <param name="allergens">Allergens.</param>
        /// <returns>true if there is an allergy to this allergen, false otherwise.</returns>
        public bool IsAllergicTo(Allergens allergens)
        {
            return (this.scor & (int)allergens) != 0;
        }

        /// <summary>
        /// Determines the full list of allergies of the person with given allergy test score.
        /// </summary>
        /// <returns>Full list of allergies of the person with given allergy test score.</returns>
        public Allergens[] AllergensList()
        {
            List<Allergens> allergensList = new List<Allergens>();
            Array allergenValues = Enum.GetValues(typeof(Allergens));

            for (int i = 0; i < allergenValues.Length; i++)
            {
                Allergens allergen = (Allergens)allergenValues.GetValue(i) !;
                if (this.IsAllergicTo(allergen))
                {
                    allergensList.Add(allergen);
                }
            }

            return allergensList.ToArray();
        }
    }
}
