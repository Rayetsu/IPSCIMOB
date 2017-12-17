using IPSCIMOB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Data
{
    public static class Seed
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //public Seed(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        //private ApplicationDbContext _context;

        //public Seed(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

            public static void SeedData(ApplicationDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            Initialize(_context);
            SeedUsers(_userManager);
        }



        public static void Initialize(ApplicationDbContext _context)
        {
            _context.Database.EnsureCreated();

            if (/*_context.ApplicationUser.Any() &&*/ _context.InformacaoGeral.Any() && _context.Sugestao.Any())
            {
                return;
            }


            //var now = DateTime.Now;
            //    var myDate = new DateTime(now.Year, now.Month, 1);
                
            

            //var user = new ApplicationUser
            //{
            //    Nome = "CIMOB",
            //    NumeroInterno = 142547145, 
            //    NumeroDoBI = 325547456,
            //    DataDeNascimento = myDate,
            //    UserName = "cimob@email.com",
            //    NormalizedUserName = "CIMOB@EMAIL.COM",
            //    Email = "cimob@email.com",
            //    NormalizedEmail = "CIMOB@EMAIL.COM",
            //    EmailConfirmed = true,
            //    LockoutEnabled = false,
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //if (_context.Users.Any(u => u.UserName == user.UserName))
            //{
            //    var password = new PasswordHasher<ApplicationUser>();
            //    var hashed = password.HashPassword(user, "Ips123!");
            //    user.PasswordHash = hashed;
            //    var userStore = new UserStore<ApplicationUser>(_context);
            //    await userStore.CreateAsync(user);
            //    await userStore.AddToRoleAsync(user, "CIMOB");
            //}

            //var user2 = new ApplicationUser
            //{
            //    Nome = "ALUNO",
            //    NumeroInterno = 356987741,
            //    NumeroDoBI = 325478741,
            //    DataDeNascimento = myDate,
            //    PartilhaMobilidade = true,
            //    IsDadosVerificados = true,
            //    UserName = "aluno@email.com",
            //    NormalizedUserName = "ALUNO@EMAIL.COM",
            //    Email = "aluno@email.com",
            //    NormalizedEmail = "ALUNO@EMAIL.COM",
            //    EmailConfirmed = true,
            //    LockoutEnabled = false,
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //if (_context.Users.Any(u => u.UserName == user2.UserName))
            //{
            //    var password = new PasswordHasher<ApplicationUser>();
            //    var hashed = password.HashPassword(user2, "Ips123!");
            //    user2.PasswordHash = hashed;
            //    var userStore = new UserStore<ApplicationUser>(_context);
            //    await userStore.CreateAsync(user2);
            //    await userStore.AddToRoleAsync(user2, "Aluno");
            //}

            //var user3 = new ApplicationUser
            //{
            //    Nome = "Funcionário",
            //    NumeroInterno = 145365214,
            //    NumeroDoBI = 369321365,
            //    DataDeNascimento = myDate,
            //    PartilhaMobilidade = true,
            //    IsFuncionario = true,
            //    IsDadosVerificados = true,
            //    UserName = "funcionario@email.com",
            //    NormalizedUserName = "FUNCIONARIO@EMAIL.COM",
            //    Email = "funcionario@email.com",
            //    NormalizedEmail = "FUNCIONARIO@EMAIL.COM",
            //    EmailConfirmed = true,
            //    LockoutEnabled = false,
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //if (_context.Users.Any(u => u.UserName == user3.UserName))
            //{
            //    var password = new PasswordHasher<ApplicationUser>();
            //    var hashed = password.HashPassword(user3, "Ips123!");
            //    user3.PasswordHash = hashed;
            //    var userStore = new UserStore<ApplicationUser>(_context);
            //    await userStore.CreateAsync(user3);
            //    await userStore.AddToRoleAsync(user3, "Funcionário");
            //}

            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('InformacaoGeral', RESEED, 0)");

            _context.InformacaoGeral.Add( new InformacaoGeral
            {
                Titulo = "Programa Vasco Da Gama",
                Descricao = "<div class=\"center-justified\"> <p>O programa Vasco da Gama é um programa de mobilidade de estudantes entre escolas do ensino politécnico.</p> <p>O intercâmbio de estudantes ao abrigo do programa implica um acordo prévio entre a instituição de origem e a instituição de acolhimento, assinado pelos respectivos responsáveis.</p> <p>A mobilidade de estudantes abrange também os estágios, trabalhos de fim de curso ou projectos finais, desde que as referidas actividades integrem o plano curricular do curso na escola de origem.</p> </div> <div class=\"center-justified\"> <h3>Período de candidatura:</h3> <ul> <li>Até 30 de abril para o 1º semestre</li> <li>Até 30 de novembro para o 2º semestre</li> </ul> </div>"
            });


            _context.InformacaoGeral.Add(new InformacaoGeral
            {
                Titulo = "Politécnico de Macau",
                Descricao = "<div class=\"center-justified\"> <p>O Programa Politécnico de Macau destina-se a estudantes que cumpram os requisitos previstos no <a href=\"https://www.si.ips.pt/ips_si/web_gessi_docs.download_file?p_name=F-102843010/Regulamento%20Mobilidade%20Internacional%20do%20IPS_Out_2014.pdf\"> Regulamento da Mobilidade Internacional do IPS(PDF | 217KB)</a></p><p>Adicionalmente, os estudantes deverão possuir conhecimentos de Inglês ao nível de Utilizador Proficiente, uma vez que as aulas são lecionadas em Inglês e os Professores não falam Português.</p><p> <h3>Despesas:</h3></p><p><h4>Estudantes</h4></p><ul><li>Seguro de saúde válido no país de destino</li><li>Deslocações intercontinentais (viagem)</li></ul><p><h4>IPMacau</h4></p><ul><li>Alojamento</li><li>Alimentação</li><li>Pocket Money</li><li>Seguro de acidentes no âmbito das actividades escolares</li><li>Deslocações internas (caso se justifique)</li></ul><p><h3>Consulta a informação disponível sobre oferta:</h3></p><a href = \"http://www.ipm.edu.mo/student_corner/en/download_course_description.php\" > Instituto Politécnico de Macau</a></div>"
            });


            _context.InformacaoGeral.Add(new InformacaoGeral
            {
                Titulo = "Erasmus+",
                Descricao = "<div class=\"center-justified\"><p>O Programa Erasmus destina-se a apoiar as actividades europeias das instituições de ensino superior(IES), promovendo a mobilidade e o intercâmbio de estudantes, professores e funcionários das Instituições de Ensino Superior.No que respeita à mobilidade de estudantes, visa oferecer a possibilidade de efectuar um período de estudos, com pleno reconhecimento académico, com a duração mínima de 5 meses e máxima de 1 ano lectivo, num estabelecimento de ensino superior de outro Estado elegível, dotado de Carta Universitária Erasmus. </p> </div>"
            });




            _context.Sugestao.Add(new Sugestao
            {
                EmailUtilizador = "aluno@email.com",
                TextoSugestao = "Eu sugiro que...."
            });

            _context.SaveChanges();

        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if(userManager.FindByNameAsync("cimob").Result == null)
            {
                ApplicationUser user1 = new ApplicationUser
                {
                    UserName = "cimob@email.com",
                    Email = "cimob@email.com",
                    Nome = "CIMOB",
                    NumeroInterno = 142547145,
                    NumeroDoBI = 325547456,
                    Morada = "rua",
                    Telefone = 123456789,
                    DataDeNascimento = new DateTime(2000, 1, 1),
                    EmailConfirmed = true,
                    IsDadosVerificados = true
                };

                IdentityResult result = userManager.CreateAsync(user1,"Ips123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user1, "CIMOB").Wait();
                }
                else
                {
                    var exception = new ApplicationException("Not working");
                    
                    throw exception;
                }

            }
        }
    }
}
