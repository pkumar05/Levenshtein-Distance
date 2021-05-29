using FluentValidation;
using LD.Domain.DTO;
using LD.Domain.Interfaces;

namespace LD.Domain.Validator
{
    public class FindLevenshteinDistanceValidator : BaseValidator<FindLevenshteinDistanceRequest>
    {
       // private readonly IGenericStringsComputationsRequestRepos _genericStringsComputationsRequestRepos;
        public FindLevenshteinDistanceValidator() //IGenericStringsComputationsRequestRepos genericStringsComputationsRequestRepos) 
        {

           //_genericStringsComputationsRequestRepos = genericStringsComputationsRequestRepos;

            RuleFor(source => source.Source)
               .NotEmpty().WithMessage("Source is required");

            RuleFor(target => target.Target)
               .NotEmpty().WithMessage("Target is required");


        }

    }
}
