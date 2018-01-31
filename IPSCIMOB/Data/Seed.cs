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
                Nome = "Instituto Politécnico de Madrid",
                Pais = "Espanha",
                Cidade = "Madrid",
                ProgramaNome = "Erasmus+ FUNCIONÁRIOS"
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
                Nome = "Instituto Politécnico de Brasilia",
                Pais = "Brasil",
                Cidade = "Brasilia",
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
                Nome = "Instituto Politécnico de Macau",
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


            // Sugestões 

            _context.Sugestao.Add(new Sugestao
            {
                EmailUtilizador = "aluno@email.com",
                TextoSugestao = "Eu sugiro que...."
            });

            _context.SaveChanges();

        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("cimob@email.com").Result == null)
            {
                ApplicationUser user1 = new ApplicationUser
                {
                    UserName = "cimob@email.com",
                    Email = "cimob@email.com",
                    Nome = "CIMOB",
                    NumeroInterno = 142517140,
                    NumeroDoBI =    325434721,
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
                    IsDadosVerificados = true
                };

                IdentityResult result = userManager.CreateAsync(user1, "Ips123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user1, "CIMOB").Wait();
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
                        PartilhaMobilidade = true
                    };

                    IdentityResult result2 = userManager.CreateAsync(user2, "Ips123!").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user2, "Aluno").Wait();
                    }


                }

                if (userManager.FindByNameAsync("funcionario@email.com").Result == null)
                {
                    ApplicationUser user3 = new ApplicationUser
                    {
                        UserName = "funcionario@email.com",
                        Email = "funcionario@email.com",
                        Nome = "FUNCIONARIO",
                        NumeroInterno = 142542155,
                        NumeroDoBI =    325547443,
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

                    IdentityResult result3 = userManager.CreateAsync(user3, "Ips123!").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user3, "Funcionário").Wait();
                    }

                }
            }
        }
    }
}