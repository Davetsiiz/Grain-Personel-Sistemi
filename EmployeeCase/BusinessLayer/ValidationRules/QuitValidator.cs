using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class QuitValidator:AbstractValidator<EmployeeQuit>
    {
        public QuitValidator()
        {
            RuleFor(x => x.EmployeeFirstname)
                .NotEmpty().WithMessage("Boş Bırakılmamalı.")
                .MaximumLength(25).WithMessage("25 Karakterden az olmalıdır.")
                .MinimumLength(2).WithMessage("2 Karakterden fazla olmalıdır.");

            RuleFor(x => x.EmployeeLastname).NotEmpty().WithMessage("Boş Bırakılmamalı.")
                .MaximumLength(25).WithMessage("25 Karakterden az olmalıdır.")
                .MinimumLength(2).WithMessage("2 Karakterden fazla olmalıdır.");

            RuleFor(x => x.EmployeeIdentityNumber)
                 .NotEmpty().WithMessage("Boş Bırakılmamalı.")
                 .Must(x => x.All(char.IsDigit)).WithMessage("Sadece sayısal değerler içermelidir.")
                 .MaximumLength(11).WithMessage("11 Haneli olmalı.")
                 .MinimumLength(11).WithMessage("11 Haneli olmalı.");

            RuleFor(x => x.EmployeeBirthDate)
                .NotEmpty().WithMessage("Boş bırakılamaz.")
                .Must(x => x is DateTime)
                .WithMessage("Tarih formatı olarak giriniz. örn: 01.01.2000");

            RuleFor(x => x.EmployeeBirthPlace)
                .NotEmpty().WithMessage("Boş Bırakılmamalı.")
                .MaximumLength(50).WithMessage("50 Karakterden az olmalıdır.")
                .MinimumLength(4).WithMessage("4 Karakterden fazla olmalıdır.");

            RuleFor(x => x.EmployeeAdress1)
                .NotEmpty().WithMessage("Boş Bırakılmamalı.")
                .MaximumLength(50).WithMessage("50 Karakterden az olmalıdır.")
                .MinimumLength(10).WithMessage("10 Karakterden fazla olmalıdır.");

            RuleFor(x => x.EmployeeAdress1)
                .MaximumLength(50).WithMessage("50 Karakterden az olmalıdır.")
                 .When(x => !string.IsNullOrEmpty(x.EmployeeTelNo2))
                 .MinimumLength(10).WithMessage("10 Karakterden az olmalıdır.")
                 .When(x => !string.IsNullOrEmpty(x.EmployeeTelNo2));

            RuleFor(x => x.EmployeeTelNo1)
                 .NotEmpty().WithMessage("Boş Bırakılmamalı.")
                 .Must(x => x.All(char.IsDigit)).WithMessage("Sadece sayısal değerler içermelidir.")
                 .MaximumLength(11).WithMessage("11 Haneli olmalı.")
                 .MinimumLength(11).WithMessage("11 Haneli olmalı.");

            RuleFor(x => x.EmployeeTelNo2)
                 .MaximumLength(11).WithMessage("11 haneli olmalıdır.")
                 .When(x => !string.IsNullOrEmpty(x.EmployeeTelNo2))
                 .MinimumLength(11).WithMessage("11 Haneli olmalı.")
                 .When(x => !string.IsNullOrEmpty(x.EmployeeTelNo2))
                 .Must(x => x.All(char.IsDigit)).WithMessage("Sadece sayısal karakterler içermelidir.")
                 .When(x => !string.IsNullOrEmpty(x.EmployeeTelNo2));

            RuleFor(x => x.EmployeeDegree)
                .NotEmpty().WithMessage("Boş Bırakılmamalı.")
                .MaximumLength(20).WithMessage("20 Karakterden az olmalıdır.")
                .MinimumLength(3).WithMessage("3 Karakterden fazla olmalıdır.");

            RuleFor(x => x.EmployeeWorkStartDate)
                .NotEmpty().WithMessage("Boş bırakılamaz.")
                .Must(x => x is DateTime)
                .WithMessage("Tarih formatı olarak giriniz. örn: 01.01.2000");

            RuleFor(x => x.EmployeeWorkQuittDate)
                .NotEmpty().WithMessage("Boş bırakılamaz.")
                .Must(x => x is DateTime)
                .WithMessage("Tarih formatı olarak giriniz. örn: 01.01.2000");
        }
    }
}
