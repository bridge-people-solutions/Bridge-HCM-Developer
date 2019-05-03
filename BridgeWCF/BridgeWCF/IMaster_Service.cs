using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BridgeWCF.Library;

namespace BridgeWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMaster_Service" in both code and config file together.
    [ServiceContract]
    public interface IMaster_Service
    {
        [OperationContract]
        login_authentication user_authenticate(string username, string userhash);

        [OperationContract]
        List<menu_view_restriction_lib> menu_view_restriction(int user_group_id, int module_id, int company_id, int warehouse_id);
    }
}
