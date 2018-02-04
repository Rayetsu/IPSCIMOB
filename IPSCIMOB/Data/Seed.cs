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

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            //Adicionar Administrador CIMOB
            if (userManager.FindByNameAsync("cimob@email.com").Result == null)
            {
                ApplicationUser user1 = new ApplicationUser
                {
                    UserName = "cimob@email.com",
                    Email = "cimob@email.com",
                    Nome = "CIMOB",
                    NumeroInterno = 142517140,
                    NumeroDoBI = 325434721,
                    Morada = "rua Ali e Aqui",
                    NumeroDaPorta = 6,
                    Andar = "1ºDto.",
                    CodigoPostal = "2867-064",
                    Cidade = "Almada",
                    Distrito = "Setúbal",
                    Nacionalidade = "Portugal",
                    Telefone = 921451289,
                    DataDeNascimento = new DateTime(1976, 10, 15),
                    EmailConfirmed = true,
                    IsDadosVerificados = true,                                
                };

                IdentityResult result1 = userManager.CreateAsync(user1, "Ips123!").Result;

                if (result1.Succeeded)
                {
                    userManager.AddToRoleAsync(user1, "CIMOB").Wait();
                }
            }


            if (userManager.FindByNameAsync("aluno@email.com").Result == null)
            {
                ApplicationUser user2 = new ApplicationUser
                {
                    UserName = "aluno@email.com",
                    Email = "aluno@email.com",
                    Nome = "ALUNO",
                    NumeroInterno = 142327134,
                    NumeroDoBI = 915542421,
                    Morada = "rua",
                    NumeroDaPorta = 3,
                    Andar = "2ºDto.",
                    CodigoPostal = "2844-014",
                    Cidade = "Seixal",
                    Distrito = "Setúbal",
                    Nacionalidade = "Portugal",
                    Telefone = 123453489,
                    DataDeNascimento = new DateTime(2000, 12, 9),
                    EmailConfirmed = true,
                    IsDadosVerificados = true,
                    PartilhaMobilidade = true,
                    IsFuncionario = false
                };

                IdentityResult result2 = userManager.CreateAsync(user2, "Ips123!").Result;

                if (result2.Succeeded)
                {
                    userManager.AddToRoleAsync(user2, "Aluno").Wait();
                }
            }

            // Adiciona Aluno Tiago
            if (userManager.FindByNameAsync("someone1995@hotmail.com").Result == null)
            {
                ApplicationUser user3 = new ApplicationUser
                {
                    UserName = "someone1995@hotmail.com",
                    Email = "someone1995@hotmail.com",
                    Nome = "Tiago Veiga Branco",
                    NumeroInterno = 140221050,
                    NumeroDoBI = 13319629,
                    Morada = "rua Pateira de Fermentelos",
                    NumeroDaPorta = 29,
                    Andar = "0",
                    CodigoPostal = "2855-622",
                    Cidade = "Corroios",
                    Distrito = "Setúbal",
                    Nacionalidade = "Portuguesa",
                    Telefone = 912075782,
                    DataDeNascimento = new DateTime(1995, 08, 09),
                    EmailConfirmed = true,
                    IsDadosVerificados = true,
                    PartilhaMobilidade = true,
                    CandidaturaAtual = 1,
                    IsMobilidade = true,
                    IsFuncionario = false
                };

                IdentityResult result3 = userManager.CreateAsync(user3, "Ips123!").Result;

                if (result3.Succeeded)
                {
                    userManager.AddToRoleAsync(user3, "Aluno").Wait();
                }
            }


            // Adiciona aluno Francisco 
            if (userManager.FindByNameAsync("francisco.alves@estudantes.ips.pt").Result == null)
            {
                ApplicationUser user4 = new ApplicationUser
                {
                    UserName = "francisco.alves@estudantes.ips.pt",
                    Email = "francisco.alves@estudantes.ips.pt",
                    Nome = "Francisco",
                    NumeroInterno = 140221019,
                    NumeroDoBI = 14080383,
                    Morada = "rua ramiro ferrão",
                    NumeroDaPorta = 6,
                    Andar = "2ºDto.",
                    CodigoPostal = "2800-064",
                    Cidade = "Almada",
                    Distrito = "Setúbal",
                    Nacionalidade = "Portugal",
                    Telefone = 921524874,
                    DataDeNascimento = new DateTime(1995, 07, 25),
                    EmailConfirmed = true,
                    IsDadosVerificados = true,
                    CandidaturaAtual = 3,
                    IsMobilidade = true,
                    IsFuncionario = false
                };

                IdentityResult result4 = userManager.CreateAsync(user4, "Ips123!").Result;

                if (result4.Succeeded)
                {
                    userManager.AddToRoleAsync(user4, "Aluno").Wait();
                }
            }

            // Adiciona aluno Gabriel 
            if (userManager.FindByNameAsync("140221075@estudantes.ips.pt").Result == null)
            {
                ApplicationUser user5 = new ApplicationUser
                {
                    UserName = "140221075@estudantes.ips.pt",
                    Email = "140221075@estudantes.ips.pt",
                    Nome = "Gabriel",
                    NumeroInterno = 140221075,
                    NumeroDoBI = 12345678,
                    Morada = "Avenida Nuno Correia",
                    NumeroDaPorta = 2,
                    Andar = "2ºDto.",
                    CodigoPostal = "2800-084",
                    Cidade = "Almada",
                    Distrito = "Setúbal",
                    Nacionalidade = "Portugal",
                    Telefone = 921222321,
                    DataDeNascimento = new DateTime(1994, 10, 25),
                    EmailConfirmed = true,
                    IsDadosVerificados = true,
                    CandidaturaAtual = 4,
                    IsMobilidade = true,
                    IsFuncionario = false
                };

                IdentityResult result5 = userManager.CreateAsync(user5, "Ips123!").Result;

                if (result5.Succeeded)
                {
                    userManager.AddToRoleAsync(user5, "Aluno").Wait();
                }
            }

            // Adiciona Aluno Diogo 
            if (userManager.FindByNameAsync("140221051@estudantes.ips.pt").Result == null)
            {
                ApplicationUser user6 = new ApplicationUser
                {
                    UserName = "140221051@estudantes.ips.pt",
                    Email = "140221051@estudantes.ips.pt",
                    Nome = "Diogo",
                    NumeroInterno = 140221051,
                    NumeroDoBI = 1234556678,
                    Morada = "Avenida da vida",
                    NumeroDaPorta = 2,
                    Andar = "2ºDto.",
                    CodigoPostal = "2800-084",
                    Cidade = "Almada",
                    Distrito = "Setúbal",
                    Nacionalidade = "Portugal",
                    Telefone = 921222322,
                    DataDeNascimento = new DateTime(1995, 01, 25),
                    EmailConfirmed = true,
                    IsDadosVerificados = true,
                    CandidaturaAtual = 5,
                    IsMobilidade = true,
                    IsFuncionario = false
                };

                IdentityResult result6 = userManager.CreateAsync(user6, "Ips123!").Result;

                if (result6.Succeeded)
                {
                    userManager.AddToRoleAsync(user6, "Aluno").Wait();
                }
            }
            // Adiciona um funcionário
            if (userManager.FindByNameAsync("funcionario@email.com").Result == null)
            {
                ApplicationUser user7 = new ApplicationUser
                {
                    UserName = "funcionario@email.com",
                    Email = "funcionario@email.com",
                    Nome = "FUNCIONARIO",
                    NumeroInterno = 142542155,
                    NumeroDoBI = 325547443,
                    Morada = "rua",
                    NumeroDaPorta = 1,
                    Andar = "3ºDto.",
                    CodigoPostal = "2800-064",
                    Cidade = "Corroios",
                    Distrito = "Setúbal",
                    Nacionalidade = "Portugal",
                    Telefone = 963456129,
                    DataDeNascimento = new DateTime(1980, 3, 12),
                    EmailConfirmed = true,
                    IsDadosVerificados = true,
                    PartilhaMobilidade = true,
                    IsFuncionario = true

                };

                IdentityResult result7 = userManager.CreateAsync(user7, "Ips123!").Result;

                if (result7.Succeeded)
                {
                    userManager.AddToRoleAsync(user7, "Funcionário").Wait();
                }
            }

            // Adiciona um Docente Nuno 
            if (userManager.FindByNameAsync("nunopina@email.com").Result == null)
            {
                ApplicationUser user7 = new ApplicationUser
                {
                    UserName = "nunopina@email.com",
                    Email = "nunopina@email.com",
                    Nome = "Nuno Pina Gonçalves",
                    NumeroInterno = 001221020,
                    NumeroDoBI = 322127443,
                    Morada = "rua das Gencianas ",
                    NumeroDaPorta = 45,
                    Andar = "1ºDto.",
                    CodigoPostal = "2865-034",
                    Cidade = "Lisboa",
                    Distrito = "Lisboa",
                    Nacionalidade = "Portuguesa",
                    Telefone = 963474829,
                    DataDeNascimento = new DateTime(1970, 2, 21),
                    EmailConfirmed = true,
                    IsDadosVerificados = true,
                    PartilhaMobilidade = true,
                    IsFuncionario = true,
                    IsMobilidade = false                     
                };

                IdentityResult result7 = userManager.CreateAsync(user7, "Ips123!").Result;

                if (result7.Succeeded)
                {
                    userManager.AddToRoleAsync(user7, "Funcionário").Wait();
                }
            }

            // Adiciona um Docente Paulo 
            if (userManager.FindByNameAsync("paulofournier@email.com").Result == null)
            {
                ApplicationUser user8 = new ApplicationUser
                {
                    UserName = "paulofournier@email.com",
                    Email = "paulofournier@email.com",
                    Nome = "Paulo Fournier",
                    NumeroInterno = 001221045,
                    NumeroDoBI = 319483443,
                    Morada = "rua Reserva Natural do Sado ",
                    NumeroDaPorta = 5,
                    Andar = "0",
                    CodigoPostal = "2854-032",
                    Cidade = "Azeitão",
                    Distrito = "Setúbal",
                    Nacionalidade = "Portuguesa",
                    Telefone = 963304299,
                    DataDeNascimento = new DateTime(1987, 09, 30),
                    EmailConfirmed = true,
                    IsDadosVerificados = true,
                    PartilhaMobilidade = true,
                    IsFuncionario = true,
                    CandidaturaAtual = 2,
                    IsMobilidade = true                    
                };

                IdentityResult result8 = userManager.CreateAsync(user8, "Ips123!").Result;

                if (result8.Succeeded)
                {
                    userManager.AddToRoleAsync(user8, "Funcionário").Wait();
                }
            }
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

            _context.InformacaoGeral.Add(new InformacaoGeral
            {
                Titulo = "Programa Vasco Da Gama",
                Descricao = "<div class=\"center-justified\"> <p>O programa Vasco da Gama é um programa de mobilidade de estudantes entre escolas do ensino politécnico.</p> <p>O intercâmbio de estudantes ao abrigo do programa implica um acordo prévio entre a instituição de origem e a instituição de acolhimento, assinado pelos respectivos responsáveis.</p> <p>A mobilidade de estudantes abrange também os estágios, trabalhos de fim de curso ou projectos finais, desde que as referidas actividades integrem o plano curricular do curso na escola de origem.</p> </div> <div class=\"center-justified\"> <h3>Período de candidatura:</h3> <ul> <li>Até 30 de abril para o 1º semestre</li> <li>Até 30 de novembro para o 2º semestre</li> </ul> </div>"
            });


            _context.InformacaoGeral.Add(new InformacaoGeral
            {
                Titulo = "Politécnico de Macau",
                Descricao = "<div class=\"center-justified\"> <p>O Programa Politécnico de Macau destina-se a estudantes que cumpram os requisitos previstos no <a href=\"https://www.si.ips.pt/ips_si/web_gessi_docs.download_file?p_name=F-102843010/Regulamento%20Mobilidade%20Internacional%20do%20IPS_Out_2014.pdf\" target=\"_blank\"> Regulamento da Mobilidade Internacional do IPS(PDF | 217KB)</a></p><p>Adicionalmente, os estudantes deverão possuir conhecimentos de Inglês ao nível de Utilizador Proficiente, uma vez que as aulas são lecionadas em Inglês e os Professores não falam Português.</p><p> <h3>Despesas:</h3></p><p><h4>Estudantes</h4></p><ul><li>Seguro de saúde válido no país de destino</li><li>Deslocações intercontinentais (viagem)</li></ul><p><h4>IPMacau</h4></p><ul><li>Alojamento</li><li>Alimentação</li><li>Pocket Money</li><li>Seguro de acidentes no âmbito das actividades escolares</li><li>Deslocações internas (caso se justifique)</li></ul><p><h3>Consulta a informação disponível sobre oferta:</h3></p><a href = \"http://www.ipm.edu.mo/student_corner/en/download_course_description.php\" target=\"_blank\" > Instituto Politécnico de Macau</a></div>"
            });


            _context.InformacaoGeral.Add(new InformacaoGeral
            {
                Titulo = "Erasmus+",
                Descricao = "<div class=\"center-justified\"><p>O Programa Erasmus destina-se a apoiar as actividades europeias das instituições de ensino superior(IES), promovendo a mobilidade e o intercâmbio de estudantes, professores e funcionários das Instituições de Ensino Superior.No que respeita à mobilidade de estudantes, visa oferecer a possibilidade de efectuar um período de estudos, com pleno reconhecimento académico, com a duração mínima de 5 meses e máxima de 1 ano lectivo, num estabelecimento de ensino superior de outro Estado elegível, dotado de Carta Universitária Erasmus. </p> </div>"
            });

            _context.InformacaoGeral.Add(new InformacaoGeral
            {
                Titulo = "Santander Universidades",
                Descricao = "<div class=\"center-justified\"><p>O Programa Santander universidades oferece bolsas para licenciatura e mestrado Ibero-América, bolsas de mobilidade luso-brasileiras e bolsas de estágio em Portugal.</p><p><h3>Mais Informações: </h3></p><p><a href = \"http://www.bolsas-santander.com/\" target=\"_blank\" > Bolsas Santander</a></p></div>"
            });

            _context.InformacaoGeral.Add(new InformacaoGeral
            {
                Titulo = "Santander Universidades Missões de Ensino e Formação oferece bolsas ",
                Descricao = "<div class=\"center-justified\"><p>O Programa Santander universidades Missões de Ensino e Formação oferece bolsas Ibero-América e bolsas luso-brasileiras.</p><p><h3>Mais Informações: </h3></p><p><a href = \"http://www.bolsas-santander.com/\" target=\"_blank\"> Bolsas Santander</a></p></div>"
            });

            _context.InformacaoGeral.Add(new InformacaoGeral
            {
                Titulo = "Sobre o CIMOB",
                Descricao = "Adicione Informações..."
            });

            _context.InformacaoGeral.Add(new InformacaoGeral
            {
                Titulo = "Bolsas de Estudo",
                Descricao = "Adicione Informações..."
            });

            _context.InformacaoGeral.Add(new InformacaoGeral
            {
                Titulo = "Documentação",
                Descricao = "<div class=\"center-justified\"><p><h3>Instituto Politécnico de Setúbal (IPS)</h3></p></p><p><h4 align=\"center\">Artigo 38º</h4></p></div><p>Documentação</p><p>Sem prejuízo das regras fixadas por cada programa referido no nº 1 do artigo 2º, considera-se obrigatório que cada processo de docente IPS em mobilidade seja constituído pela seguinte documentação:</p><p>a) Acordo Bilateral ou equivalente legal (celebrado antes da realização da mobilidade, e estabelecido entre o IPS e uma instituição parceira, de carácter nacional ou internacional);</p><p>b) Ficha de Candidatura, nos termos do artigo 31º;</p><p>c) Ficha de Docente;</p><p>d) Contrato de Docente;</p><p>e) Confirmação do período de leccionação/estada no estrangeiro, emitida pela instituição de acolhimento;</p><p>f) Recibo de pagamento da bolsa (quando aplicável);</p><p>g) Relatório Final Individual;</p><p>h) Adendas ao Contrato (quando aplicável);</p><p>i) Recibos relativos a Adendas ao Contrato (quando aplicável).</p><h3>Mais Informações: </h3></p> <p><a href = \"https://www.ips.pt/ips_si/file_get.legislacao_cont?p_id=F1154480549/Regulamento_Mobilidade.pdf\" target=\"_blank\">REGULAMENTO DE MOBILIDADE INTERNACIONAL DA COMUNIDADE IPS</a></p>",
            });

            _context.InformacaoGeral.Add(new InformacaoGeral
            {
                Titulo = "Regulamento",
                Descricao = "  <p>INSTITUTO POLITÉCNICO DE SETÚBAL(IPS)</p>No âmbito da criação do CIMOB - IPS, e da aposta no desenvolvimento da internacionalização da actividade do IPS e suas unidades orgânicas, torna-se essencial estabelecer um conjunto de regras e critérios cuja aplicação defina, em articulação com as normas comunitárias e extra comunitárias em vigor, uma mobilidade internacional de qualidade, com rigor e transparência e que contribua para o desenvolvimento da comunidade académica do IPS enquanto instituição de ensino superior em Portugal, na Europa e no Mundo. Ouvidas as Escolas, o CIMOB-IPS propõe à Comissão Permanente do Conselho Geral o seguinte Regulamento de Mobilidade da Comunidade IPS: <p> <p><h3> </h3></p><p><a href = \"https://www.ips.pt/ips_si/file_get.legislacao_cont?p_id=F1154480549/Regulamento_Mobilidade.pdf\" target=\"_blank\">REGULAMENTO DE MOBILIDADE INTERNACIONAL DA COMUNIDADE IPS</a></p></p> "
            });

            // Ajudas

            _context.Ajuda.Add(new Ajuda
            {
                Nome = "Registo",
                Descricao = "Preencha os campos com as suas informações corretas. Em seguida clique em registar. <p>Depois deverá confirmar o seu registo, no email que foi enviado para o seu email.</p>"
            });

            _context.Ajuda.Add(new Ajuda
            {
                Nome = "Login",
                Descricao = "Realize o login colocando o seu email e password.<p>Se não sabe a password clique no link de ajuda de recuperação de Passwod.</p>"
            });

            _context.Ajuda.Add(new Ajuda
            {
                Nome = "Esqueceu-se da PW?",
                Descricao = "Coloque o email que utilizou no registo e verifique o email para redefinir a password."
            });

            _context.Ajuda.Add(new Ajuda
            {
                Nome = "Alterar Dados",
                Descricao = "Altere os dados"
            });

            _context.Ajuda.Add(new Ajuda
            {
                Nome = "Alterar Pw",
                Descricao = "Coloque a sua pw atual.Em seguida coloque uma nova pw e repita-a para finalizar"
            });



            _context.Ajuda.Add(new Ajuda
            {
                Nome = "Processo de Candidatura: Inicio",
                Descricao = "Adicione Informações..."
            });

            _context.Ajuda.Add(new Ajuda
            {
                Nome = "Processo de Candidatura: Passo 1 ",
                Descricao = "Proceda ao preenchimento dos dados referentes à candidatura.<p>Se pretende ser candidato à bolsa, o semestre que predende e a Instituição.</p> <p>Em seguida carregue em Submeter Candidatura</p>"
            });

            _context.Ajuda.Add(new Ajuda
            {
                Nome = "Processo de Candidatura: Passo 2 Regulamento",
                Descricao = "Leia o regulamento e marque que leu o regulamento para proseguir para o próximo passo."
            });

            _context.Ajuda.Add(new Ajuda
            {
                Nome = "Processo de Candidatura: Passo 3 Upload de Ficheiros",
                Descricao = "Realize o upload dos ficheiros necessarios para a candidatura. <p>Faça um upload de cada vez.</p><p>Deverá esperar que os documentos sejam aceites.</p><p>Irá rebecer um email com o resultado dos documentos, se foram aceitos passará para o passo de Marcar Entrevista</p> <p>Se foram recusados terá de realiar os uploads dos ficheiros corretos e esperar novamente pelo resultado</p><p>Deve consultar os documentos necessários no separador Documentação do menu Menu Candidatura</p> "
            });

            _context.Ajuda.Add(new Ajuda
            {
                Nome = "Processo de Candidatura: Passo 4 Marcar Entrevista",
                Descricao = "Escolha uma data e hora para a sua entrevista. Deverá esperar que a entrevista seja aceite para proseguir para o próximo passo.<p>Irá receber um email com o resultado da entrevista, aceite ou rejeitada</p><p>Se for aceite deverá comparecer na sala CIMOB da EST de Setúbal na data e hora marcada.</p> <p>Se for rejeitada deverá de marcar outra data e/ou hora para a entrevista e esperara pelo resultado.</p> <p>Pode consultar a data e hora, Nome do Programa que se candidatou e o estado das entrevias, no separador Entrevista que se encontra no menu da Candidatura </p>"
            });

            _context.Ajuda.Add(new Ajuda
            {
                Nome = "Processo de Candidatura: Passo 5 Dados Finais da Candidatura",
                Descricao = "Nesta página encontra-se os dados referentes à sua candidatura. <p>Se o estado da candidatura estiver em realização é porque ainda está em avaliação</p>"
            });

            // Alunos Estrangeiros

            _context.ForeignStudents.Add(new ForeignStudents
            {
                Nome = "Mike Tyson",
                Nacionalidade = "USA",
                Email = "mikke@gmail.com",
                DataDeNascimento = new DateTime(1995, 10, 15),
                EscolaIPSECurso = "EST, EI",
                Morada = "rua 21",
                NumeroDaPorta = 3,
                Andar = "2",
                Cidade = "New York",
                Distrito = "distric1",
                CodigoPostal = "45755-7856",
                Universidade = "NY Universaty",
                IsBolseiro = false,
                IsFuncionario = false,
                IsDadosVerificados = true
            });

            _context.ForeignStudents.Add(new ForeignStudents
            {
                Nome = "Ona Greeven",
                Nacionalidade = "Belgium",
                Email = "onaona@gmail.com",
                DataDeNascimento = new DateTime(1995, 04, 18),
                EscolaIPSECurso = "ESCE, CF",
                Morada = "rua 2",
                NumeroDaPorta = 8,
                Andar = "0",
                Cidade = "Bruxeles",
                Distrito = "Bruxeles",
                CodigoPostal = "428734-0756",
                Universidade = "Bruxeles Universaty",
                IsBolseiro = true,
                IsFuncionario = false,
                IsDadosVerificados = true
            });

            _context.ForeignStudents.Add(new ForeignStudents
            {
                Nome = "John Wick",
                Nacionalidade = "USA",
                Email = "mrwick@gmail.com",
                DataDeNascimento = new DateTime(1980, 10, 15),
                EscolaIPSECurso = "EST, EM",
                Morada = "rua 5",
                NumeroDaPorta = 2,
                Andar = "0",
                Cidade = "New York",
                Distrito = "distric4",
                CodigoPostal = "45755-7856",
                Universidade = "NY Universaty",
                IsBolseiro = false,
                IsFuncionario = true,
                IsDadosVerificados = true
            });

            _context.ForeignStudents.Add(new ForeignStudents
            {
                Nome = "Layla James",
                Nacionalidade = "Spain",
                Email = "layla@gmail.com",
                DataDeNascimento = new DateTime(1996, 01, 28),
                EscolaIPSECurso = "ESES, CS",
                Morada = "rua 8",
                NumeroDaPorta = 6,
                Andar = "7",
                Cidade = "Madrid",
                Distrito = "Madrid",
                CodigoPostal = "67755-3256",
                Universidade = "Madrid Universaty",
                IsBolseiro = true,
                IsFuncionario = false,
                IsDadosVerificados = true
            });



            // Programas de Mobilidade

            _context.ProgramaModel.Add(new ProgramaModel
            {
                Nome = "Vasco Da Gama",
                Descricao = "<div class=\"center-justified\"> <p>O programa Vasco da Gama é um programa de mobilidade de estudantes entre escolas do ensino politécnico.</p> <p>O intercâmbio de estudantes ao abrigo do programa implica um acordo prévio entre a instituição de origem e a instituição de acolhimento, assinado pelos respectivos responsáveis.</p> <p>A mobilidade de estudantes abrange também os estágios, trabalhos de fim de curso ou projectos finais, desde que as referidas actividades integrem o plano curricular do curso na escola de origem.</p> </div> <div class=\"center-justified\"> <h3>Período de candidatura:</h3> <ul> <li>Até 30 de abril para o 1º semestre</li> <li>Até 30 de novembro para o 2º semestre</li> </ul> </div>",
                ProgramaAtual = false,
                UtilizadorProfissao = UtilizadorProfissao.Aluno,
                PrazoCandidaturaPrimeiroSemestre = new DateTime(2018, 09, 15),
                PrazoCandidaturaSegundoSemestre = new DateTime(2018, 02, 15)
            });

            _context.ProgramaModel.Add(new ProgramaModel
            {
                Nome = "Politécnico de Macau",
                Descricao = "<div class=\"center-justified\"> <p>O Programa Politécnico de Macau destina-se a estudantes que cumpram os requisitos previstos no <a href=\"https://www.si.ips.pt/ips_si/web_gessi_docs.download_file?p_name=F-102843010/Regulamento%20Mobilidade%20Internacional%20do%20IPS_Out_2014.pdf\" target=\"_blank\"> Regulamento da Mobilidade Internacional do IPS(PDF | 217KB)</a></p><p>Adicionalmente, os estudantes deverão possuir conhecimentos de Inglês ao nível de Utilizador Proficiente, uma vez que as aulas são lecionadas em Inglês e os Professores não falam Português.</p><p> <h3>Despesas:</h3></p><p><h4>Estudantes</h4></p><ul><li>Seguro de saúde válido no país de destino</li><li>Deslocações intercontinentais (viagem)</li></ul><p><h4>IPMacau</h4></p><ul><li>Alojamento</li><li>Alimentação</li><li>Pocket Money</li><li>Seguro de acidentes no âmbito das actividades escolares</li><li>Deslocações internas (caso se justifique)</li></ul><p><h3>Consulta a informação disponível sobre oferta:</h3></p><a href = \"http://www.ipm.edu.mo/student_corner/en/download_course_description.php\" target=\"_blank\" > Instituto Politécnico de Macau</a></div>",
                ProgramaAtual = false,
                UtilizadorProfissao = UtilizadorProfissao.Aluno,
                PrazoCandidaturaPrimeiroSemestre = new DateTime(2018, 09, 15),
                PrazoCandidaturaSegundoSemestre = new DateTime(2018, 02, 15)
            });

            _context.ProgramaModel.Add(new ProgramaModel
            {
                Nome = "Erasmus+ FUNCIONÁRIOS",
                Descricao = "<div class=\"center-justified\"><p>No âmbito do Ensino Superior, a Ação-Chave 1 – Mobilidade Individual, do Programa ERASMUS+, oferece oportunidades a docentes e não docentes de instituições de ensino superior (IES), bem como a pessoal de organizações da sociedade civil, de participarem numa experiência noutro país europeu. </p> </div>",
                ProgramaAtual = false,
                UtilizadorProfissao = UtilizadorProfissao.Funcionario,
                PrazoCandidaturaPrimeiroSemestre = new DateTime(2018, 09, 15),
                PrazoCandidaturaSegundoSemestre = new DateTime(2018, 02, 15)
            });

            _context.ProgramaModel.Add(new ProgramaModel
            {
                Nome = "Erasmus+ ALUNOS",
                Descricao = "<div class=\"center-justified\"><p>O Programa Erasmus destina-se a apoiar as actividades europeias das instituições de ensino superior(IES), promovendo a mobilidade e o intercâmbio de estudantes das Instituições de Ensino Superior.No que respeita à mobilidade de estudantes, visa oferecer a possibilidade de efectuar um período de estudos, com pleno reconhecimento académico, com a duração mínima de 5 meses e máxima de 1 ano lectivo, num estabelecimento de ensino superior de outro Estado elegível, dotado de Carta Universitária Erasmus. </p> </div>",
                ProgramaAtual = false,
                UtilizadorProfissao = UtilizadorProfissao.Aluno,
                PrazoCandidaturaPrimeiroSemestre = new DateTime(2018, 09, 15),
                PrazoCandidaturaSegundoSemestre = new DateTime(2018, 02, 15)
            });

            _context.ProgramaModel.Add(new ProgramaModel
            {
                Nome = "Santander Universidades - BOLSAS IBERO-AMERICANAS",
                Descricao = "<div class=\"center-justified\"><p>O intercâmbio de estudantes através do Programa de Bolsas Ibero- Americanas Santander Universidades consiste na realização de um período de estudos. O intercâmbio tem obrigatoriamente de estar abrangido por um Protocolo de Cooperação com uma instituição que integre a rede deste Programa. A matrícula/inscrição e o pagamento das propinas efetuados no IPS são válidos para os estudos na universidade brasileira de destino, não havendo necessidade de qualquer matrícula adicional.</p><p><h3>Mais Informações: </h3></p><p><a href = \"http://www.bolsas-santander.com/\" target=\"_blank\" > Bolsas Santander</a></p></div>",
                ProgramaAtual = false,
                UtilizadorProfissao = UtilizadorProfissao.Aluno,
                PrazoCandidaturaPrimeiroSemestre = new DateTime(2018, 09, 15),
                PrazoCandidaturaSegundoSemestre = new DateTime(2018, 02, 15)
            });

            _context.ProgramaModel.Add(new ProgramaModel
            {
                Nome = "Santander Universidades - BOLSAS LUSO-BRASILEIRAS",
                Descricao = "<div class=\"center-justified\"><p>O intercâmbio de estudantes através do Programa de Bolsas Luso- Brasileiras Santander Universidades consiste na realização de um período de estudos. O intercâmbio tem obrigatoriamente de estar abrangido por um Protocolo de Cooperação com uma instituição que integre a rede deste Programa. A matrícula/inscrição e o pagamento das propinas efetuados no IPS são válidos para os estudos na universidade brasileira de destino, não havendo necessidade de qualquer matrícula adicional. </h3></p><p><a href = \"http://www.bolsas-santander.com/\" target=\"_blank\" > Bolsas Santander</a></p></div>",
                ProgramaAtual = false,
                UtilizadorProfissao = UtilizadorProfissao.Aluno,
                PrazoCandidaturaPrimeiroSemestre = new DateTime(2018, 09, 15),
                PrazoCandidaturaSegundoSemestre = new DateTime(2018, 02, 15)
            });

            _context.ProgramaModel.Add(new ProgramaModel
            {
                Nome = "Santander Universidades - BOLSAS IBERO-AMERICANAS SANTANDER INVESTIGAÇÃO",
                Descricao = "<div class=\"center-justified\"><p>O Programa de Bolsas Ibero-americanas Santander Investigação tem como objetivo reforçar a mobilidade e o intercâmbio de professores, investigadores e estudantes de doutoramento entre universidades e centros de investigação ibero-americanos. O intercâmbio deverá ser realizado numa instituição parceira pertencente à rede do Programa, sendo obrigatória a existência de um Protocolo de Cooperação entre o IPS e a mesma. Esta tipologia de bolsa visa promover a atualização do nível de conhecimentos, a aprendizagem de novas técnicas e métodos, e o estabelecimento ou consolidação de vínculos académicos entre equipas de investigação e instituições ibero - americanas, permitindo inclusivamente reunir informação adicional e específica necessária para os estudos ou investigações que os destinatários estejam a realizar.Especificamente, as bolsas também pretendem ajudar a completar a formação e especialização científica e técnica do pessoal investigador em formação ou dos estudantes de doutoramento. O Programa de Bolsas Ibero - Americanas Santander Investigação é patrocinado pelo Banco Santander </ p><p><h3>Mais Informações: </h3></p><p><a href = \"http://www.bolsas-santander.com/\" target=\"_blank\"> Bolsas Santander</a></p></div>",
                ProgramaAtual = false,
                UtilizadorProfissao = UtilizadorProfissao.Funcionario,
                PrazoCandidaturaPrimeiroSemestre = new DateTime(2018, 09, 15),
                PrazoCandidaturaSegundoSemestre = new DateTime(2018, 02, 15)
            });




            // Instituições Parceiras 

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Paris",
                Pais = "França",
                Cidade = "Paris",
                ProgramaNome = "Erasmus+ ALUNOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Barcelona",
                Pais = "Espanha",
                Cidade = "Barcelona",
                ProgramaNome = "Erasmus+ ALUNOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Valência",
                Pais = "Espanha",
                Cidade = "Valência",
                ProgramaNome = "Erasmus+ ALUNOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Bilbau",
                Pais = "Espanha",
                Cidade = "Bilbau",
                ProgramaNome = "Erasmus+ ALUNOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Marselha",
                Pais = "França",
                Cidade = "Marselha",
                ProgramaNome = "Erasmus+ ALUNOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Lyon",
                Pais = "França",
                Cidade = "Lyon",
                ProgramaNome = "Erasmus+ ALUNOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Genebra",
                Pais = "França",
                Cidade = "Genebra",
                ProgramaNome = "Erasmus+ ALUNOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Berlim",
                Pais = "Alemanha",
                Cidade = "Berlim",
                ProgramaNome = "Erasmus+ ALUNOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Madrid",
                Pais = "Espanha",
                Cidade = "Madrid",
                ProgramaNome = "Erasmus+ FUNCIONÁRIOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Barcelona",
                Pais = "Espanha",
                Cidade = "Barcelona",
                ProgramaNome = "Erasmus+ FUNCIONÁRIOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Genebra",
                Pais = "França",
                Cidade = "Genebra",
                ProgramaNome = "Erasmus+ FUNCIONÁRIOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Lyon",
                Pais = "França",
                Cidade = "Lyon",
                ProgramaNome = "Erasmus+ FUNCIONÁRIOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Londres",
                Pais = "Reino Unido",
                Cidade = "Londres",
                ProgramaNome = "Erasmus+ FUNCIONÁRIOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Manchester",
                Pais = "Reino Unido",
                Cidade = "Manchester",
                ProgramaNome = "Erasmus+ FUNCIONÁRIOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Brasilia",
                Pais = "Brasil",
                Cidade = "Brasilia",
                ProgramaNome = "Santander Universidades - BOLSAS IBERO-AMERICANAS SANTANDER INVESTIGAÇÃO"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Fortaleza",
                Pais = "Brasil",
                Cidade = "Fortaleza",
                ProgramaNome = "Santander Universidades - BOLSAS IBERO-AMERICANAS SANTANDER INVESTIGAÇÃO"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Pafos",
                Pais = "Chipre",
                Cidade = "Pafos",
                ProgramaNome = "Erasmus+ ALUNOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Pafos",
                Pais = "Chipre",
                Cidade = "Pafos",
                ProgramaNome = "Erasmus+ FUNCIONÁRIOS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Politécnico de Macau",
                Pais = "China",
                Cidade = "Macau",
                ProgramaNome = "Politécnico de Macau"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Lisboa",
                Pais = "Portugal",
                Cidade = "Lisboa",
                ProgramaNome = "Vasco Da Gama"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Coimbra",
                Pais = "Portugal",
                Cidade = "Coimbra",
                ProgramaNome = "Vasco Da Gama"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Instituto Politécnico de Evora",
                Pais = "Portugal",
                Cidade = "Evora",
                ProgramaNome = "Vasco Da Gama"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Universidade de São Paulo",
                Pais = "Brasil",
                Cidade = "São Paulo",
                ProgramaNome = "Santander Universidades - BOLSAS LUSO-BRASILEIRAS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Universidade Nova Iorque",
                Pais = "Estados Unidos",
                Cidade = "New York",
                ProgramaNome = "Santander Universidades - BOLSAS IBERO-AMERICANAS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Universidade de Orlando",
                Pais = "Estados Unidos",
                Cidade = "Orlando",
                ProgramaNome = "Santander Universidades - BOLSAS IBERO-AMERICANAS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Universidade de Atlanta",
                Pais = "Estados Unidos",
                Cidade = "Atlanta",
                ProgramaNome = "Santander Universidades - BOLSAS IBERO-AMERICANAS"
            });

            _context.InstituicaoParceiraModel.Add(new InstituicaoParceiraModel
            {
                Nome = "Universidade de Chicago",
                Pais = "Estados Unidos",
                Cidade = "Chicago",
                ProgramaNome = "Santander Universidades - BOLSAS IBERO-AMERICANAS"
            });

            // Sugestões 

            _context.Sugestao.Add(new Sugestao
            {
                EmailUtilizador = "aluno@email.com",
                TextoSugestao = "Eu sugiro que façam uma parceria com o Instituto Politécnico de Braga."
            });

            _context.Sugestao.Add(new Sugestao
            {
                EmailUtilizador = "someone1995@Hotmail.com",
                TextoSugestao = "O site é bastante intuitivo, porém gostava de poder enviar mensagens a outros alunos."
            });

            _context.Sugestao.Add(new Sugestao
            {
                EmailUtilizador = "paulofournier@email.com",
                TextoSugestao = "Gostava de poder fazer erasmus de formação numa Instituição/Universidade no Peru."
            });

            //Entrevista da Candidatura 1 do Aluno Tiago
            _context.Entrevista.Add(new Entrevista
            {
                //EntrevistaId = 1,
                NumeroAluno = 140221050,
                Email = "someone1995@hotmail.com",
                EntrevistaAtual = false,
                DataDeEntrevista = new DateTime (2017, 08, 16, 10, 30, 0),
                Estado = EstadoEntrevista.Aceite,
                NomePrograma = "Santander Universidades - BOLSAS IBERO - AMERICANAS"
            });
            //Candidatura 1 do Aluno Tiago
            _context.CandidaturaModel.Add(new CandidaturaModel
            {
                //CandidaturaID = 1,
                Programa = "Santander Universidades - BOLSAS IBERO - AMERICANAS",
                InstituicaoNome = "Universidade de Atlanta",
                InstituicaoPais = "Estados Unidos",
                InstituicaoCidade = "Atlanta",
                DataInicioCandidatura = new DateTime(2017, 08, 10, 10, 47, 0),
                DataFimCandidatura = new DateTime(2017, 08, 30, 10, 55, 0),
                Semestre = Semestre.PrimeiroSemestre,
                Email = "someone1995@hotmail.com",
                EntrevistaID = 1,
                Nome = "Tiago Veiga Branco",
                NumeroInterno = 140221050,
                IsBolsa = true,
                IsEstudo = false,
                IsEstagio = false,
                IsInvestigacao = false,
                IsLecionar = false,
                IsFormacao = false,
                IsConfirmado = true,
                Estado = EstadoCandidatura.EmMobilidade,
                EstadoDocumentos = EstadoDocumentos.Aceites
            });

            // Entrevista da Candidatura 2 do Funcionário Paulo
            _context.Entrevista.Add(new Entrevista
            {
                //EntrevistaId = 2,
                NumeroAluno = 001221045,
                Email = "paulofournier@email.com",
                EntrevistaAtual = false,
                DataDeEntrevista = new DateTime(2017, 07, 23, 10, 30, 0),
                Estado = EstadoEntrevista.Aceite,
                NomePrograma = "Erasmus+ FUNCIONÁRIOS"
            });
            // Candidatura 2 do Funcionário Paulo
            _context.CandidaturaModel.Add(new CandidaturaModel
            {
                //CandidaturaID = 2,
                Programa = "Erasmus+ FUNCIONÁRIOS",
                InstituicaoNome = "Instituto Politécnico de Londres",
                InstituicaoPais = "Reino Unido",
                InstituicaoCidade = "Londres",
                DataInicioCandidatura = new DateTime(2017, 06, 18, 12,21,0),
                DataFimCandidatura = new DateTime(2017, 08, 19, 17,25, 0),
                Semestre = Semestre.PrimeiroSemestre,
                Email = "paulofournier@email.com",
                EntrevistaID = 2,
                Nome = "Paulo Fournier",
                NumeroInterno = 001221045,
                IsBolsa = false,
                IsEstudo = false,
                IsEstagio = false,
                IsInvestigacao = false,
                IsLecionar = false,
                IsFormacao = true,
                IsConfirmado = true,
                Estado = EstadoCandidatura.EmMobilidade,
                EstadoDocumentos = EstadoDocumentos.Aceites
            });

            // Entrevista Candidatura 3 do Aluno Francisco
            _context.Entrevista.Add(new Entrevista
            {
                //EntrevistaId = 3,
                NumeroAluno = 140221019,
                Email = "francisco.alves@estudantes.ips.pt",
                EntrevistaAtual = false,
                DataDeEntrevista = new DateTime(2017, 07, 23, 10, 30, 0),
                Estado = EstadoEntrevista.Aceite,
                NomePrograma = "Erasmus+ ALUNOS"
            });
            // Candidatura 3 do Aluno Francisco
            _context.CandidaturaModel.Add(new CandidaturaModel
            {
                //CandidaturaID = 3,
                Programa = "Erasmus+ ALUNOS",
                InstituicaoNome = "Instituto Politécnico de Lyon",
                InstituicaoPais = "França",
                InstituicaoCidade = "Lyon",
                DataInicioCandidatura = new DateTime(2017, 06, 05, 11, 23, 0),
                DataFimCandidatura = new DateTime(2017, 08, 01, 12,34,0),
                Semestre = Semestre.PrimeiroSemestre,
                Email = "francisco.alves@estudantes.ips.pt",
                EntrevistaID = 3,
                Nome = "Francisco",
                NumeroInterno = 140221019,
                IsBolsa = true,
                IsEstudo = true,
                IsEstagio = false,
                IsInvestigacao = false,
                IsLecionar = false,
                IsFormacao = false,
                IsConfirmado = true,
                Estado = EstadoCandidatura.EmMobilidade,
                EstadoDocumentos = EstadoDocumentos.Aceites
            });
            
            // Entrevista Candidatura 4 do Aluno Gabriel 
            _context.Entrevista.Add(new Entrevista
            {
                //EntrevistaId = 4,
                NumeroAluno = 140221075,
                Email = "140221075@estudantes.ips.pt",
                EntrevistaAtual = false,
                DataDeEntrevista = new DateTime(2017, 07, 21, 10, 30, 0),
                Estado = EstadoEntrevista.Aceite,
                NomePrograma = "Erasmus+ ALUNOS"
            });
            // Candidatura 4 do Aluno Gabriel
            _context.CandidaturaModel.Add(new CandidaturaModel
            {
                //CandidaturaID = 4,
                Programa = "Erasmus+ ALUNOS",
                InstituicaoNome = "Instituto Politécnico de Bilbau",
                InstituicaoPais = "Espanha",
                InstituicaoCidade = "Bilbau",
                DataInicioCandidatura = new DateTime(2017, 06, 12, 13,45,0),
                DataFimCandidatura = new DateTime(2017, 08, 23, 16, 35, 0),
                Semestre = Semestre.PrimeiroSemestre,
                Email = "140221075@estudantes.ips.pt",
                EntrevistaID = 4,
                Nome = "Gabriel",
                NumeroInterno = 140221075,
                IsBolsa = false,
                IsEstudo = true,
                IsEstagio = false,
                IsInvestigacao = false,
                IsLecionar = false,
                IsFormacao = false,
                IsConfirmado = true,
                Estado = EstadoCandidatura.EmMobilidade,
                EstadoDocumentos = EstadoDocumentos.Aceites
            });

            // Entrevistas da Candidatura 5 do Aluno Diogo
            _context.Entrevista.Add(new Entrevista
            {
                //EntrevistaId = 5,
                NumeroAluno = 140221051,
                Email = "140221051@estudantes.ips.pt",
                EntrevistaAtual = false,
                DataDeEntrevista = new DateTime(2017, 07, 11, 10, 30, 0),
                Estado = EstadoEntrevista.Aceite,
                NomePrograma = "Santander Universidades - BOLSAS LUSO-BRASILEIRAS"
            });
            // Candidatura 5 do Aluno Diogo
            _context.CandidaturaModel.Add(new CandidaturaModel
            {
                //CandidaturaID = 5,
                Programa = "Santander Universidades - BOLSAS LUSO-BRASILEIRAS",
                InstituicaoNome = "Universidade de São Paulo",
                InstituicaoPais = "Brasil",
                InstituicaoCidade = "São Paulo",
                DataInicioCandidatura = new DateTime(2017, 06, 25, 15,34,0),
                DataFimCandidatura = new DateTime(2017, 08, 02, 13,45,0),
                Semestre = Semestre.PrimeiroSemestre,
                Email = "140221051@estudantes.ips.pt",
                EntrevistaID = 5,
                Nome = "Diogo",
                NumeroInterno = 140221051,
                IsBolsa = true,
                IsEstudo = true,
                IsEstagio = false,
                IsInvestigacao = false,
                IsLecionar = false,
                IsFormacao = false,
                IsConfirmado = true,
                Estado = EstadoCandidatura.EmMobilidade,
                EstadoDocumentos = EstadoDocumentos.Aceites
            });
            
            _context.SaveChanges();
        }        
    }
}