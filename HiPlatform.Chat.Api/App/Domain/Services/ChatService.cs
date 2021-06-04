using HiPlatform.Chat.Api.App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HiPlatform.Chat.Api.App.Domain.Services
{
    public class ChatService
    {
        private static Dictionary<int, List<MessageWrapper>> _dialogs = new Dictionary<int, List<MessageWrapper>>
        {
            {
                1, new List<MessageWrapper>
                {
                    new MessageWrapper("O Arquiteto", "Olá, Neo.", 0),
                    new MessageWrapper("Neo", "Quem é você?", 1),
                    new MessageWrapper("O Arquiteto", "Eu sou o Arquiteto. Eu criei a Matrix. Eu estava à sua espera. Você tem muitas perguntas, e embora o processo tenha alterado sua consciência, você continua irrevogavelmente humano. Assim sendo, algumas de minhas respostas você entenderá, e outras não. Em consonância, ainda que sua primeira pergunta possa ser a mais pertinente, você pode ou não se dar conta de que ela é também irrelevante.", 2),
                    new MessageWrapper("Neo", "Por que eu estou aqui?", 3),
                    new MessageWrapper("O Arquiteto", "Sua vida é a soma do saldo de uma equação desequilibrada inerente à programação da Matrix. Você é o desenlace de uma anomalia, que, a despeito de meus mais sinceros esforços, fui incapaz de eliminar daquela, caso conseguisse, seria uma harmonia de precisão matemática. Ainda que continue a ser uma tarefa árdua diligentemente evita-la, ela não é inesperada, e portanto não está além de qualquer controle. Fato este que o trouxe, inexoravelmente, aqui.", 4),
                    new MessageWrapper("Neo", "Você não respondeu à minha pergunta.", 5),
                    new MessageWrapper("O Arquiteto", "Exatamente. Interessante. Foi mais rápido do que os outros.", 6)
                }
            }, {
                2, new List<MessageWrapper>
                {
                    new MessageWrapper("Garoto", "Não tente entortar a colher. Isto é impossível. Ao invés disto tente perceber a verdade.", 0),
                    new MessageWrapper("Neo", "Que verdade?", 1),
                    new MessageWrapper("Garoto", "Não há colher.", 2),
                    new MessageWrapper("Neo", "Não há colher?", 3),
                    new MessageWrapper("Garoto", "Então você verá que não é a colher que entorta, e sim você mesmo.", 4)
                }
            }, {
                3, new List<MessageWrapper>
                {
                    new MessageWrapper("Neo", "Porque doem os meus olhos?", 0),
                    new MessageWrapper("Morpheus", "Porque você nunca os usou.", 1)
                }
            }, {
                4, new List<MessageWrapper>
                {
                    new MessageWrapper("Morpheus", "Você acredita em destino Neo?", 0),
                    new MessageWrapper("Neo", "Não!", 1),
                    new MessageWrapper("Morpheus", "Por que não?!", 2),
                    new MessageWrapper("Neo", "Não gosto da idéia de que não controlo a minha vida!", 3),
                    new MessageWrapper("Morpheus", "Sei exatamente o que quer dizer!", 4)
                }
            }
        };

        public IEnumerable<ProtocolWrapper> GetAvailableDialogs() => _dialogs.Keys.Select(x => new ProtocolWrapper(x));

        public IEnumerable<MessageWrapper> GetDialog(int protocolId)
        {
            if (protocolId == 0)
                throw new ArgumentException(nameof(protocolId), "can't be 0");

            if (!_dialogs.ContainsKey(protocolId))
                return null;

            return _dialogs[protocolId];
        }
    }
}
