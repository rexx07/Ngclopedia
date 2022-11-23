using System.ComponentModel;

namespace Ngclopedia.Domain.Forums;

public enum ArticleType
{
    [Description("To educate, promote, influence, persuade, amuse or evoke feelings. To explore and examine ideas " +
                 "surrounding an event to put the event or issue into context; to give background")]
    Feature = 10,

    [Description("To inform, provide reportage of an event or issue")]
    News = 20,

    [Description("To comment, analyse, discuss an event, issue or personality")]
    Analysis = 30,

    [Description("To influence readers, provoke controversy through an opinion")]
    Opinion = 40
}