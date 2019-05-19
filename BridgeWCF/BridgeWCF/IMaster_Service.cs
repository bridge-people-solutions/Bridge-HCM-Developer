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
        List<menu_view_restriction_lib> menu_view_restriction(int access_level_id, int module_id, int company_id);

        [OperationContract]
        List<util_dropdown_view_lib> util_dropdown_view(int setting_id, bool active, int setting_type_id, int company_id);

        [OperationContract]
        List<util_dropdown_list_lib> util_dropdown_list(int setting_type);

        [OperationContract]
        List<menu_view_restriction_lib> modules_access_view(int access_level_id, int module_id, int company_id);

        [OperationContract]
        List<menu_view_restriction_lib> modules_view(int module_id, bool is_ap, bool is_active);

        [OperationContract]
        int util_dropdown_setting_in(util_dropdown_view_lib obj);

        [OperationContract]
        menu_view_restriction_lib module_access_in(menu_view_restriction_lib[] obj, int company_id, int created_by);

        [OperationContract]
        warehouse_in_up_lib warehouse_in_up(warehouse_in_up_lib obj);

        [OperationContract]
        int file_manager_in(file_manager_in_lib objHeader);

        [OperationContract]
        int util_dropdown_setting_up(util_dropdown_view_lib obj);

        [OperationContract]
        List<employee_list_view_lib> employee_list_view(employee_list_view_lib obj);

        [OperationContract]
        List<warehouse_view_lib> warehouse_view(int warehouse_id, int company_id, bool is_active, bool is_ap);

        [OperationContract]
        approval_process_in_lib approval_process_in(approval_process_in_lib[] obj, int approval_group_id, int module_id, bool all, int company_id, int warehouse_id, int created_by);

        [OperationContract]
        List<approval_process_in_lib> approval_process_view(int module_id, int approval_group_id, int warehouse_id, int company_id);
    }
}
