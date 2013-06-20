using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ExButtons : MonoBehaviour
{
    private MrdPrt mrdPrt;
	// Use this for initialization
    void Start ()
    {
        mrdPrt = GetComponent<MrdPrt> ();
    }
	// Update is called once per frame
    void Update ()
    {

    }

    void OnGUI ()
    {
//        left side
        if (GUI.Button (new Rect(10, 10, 130, 45), "Register")) {
            Register ();
        }

        if (GUI.Button (new Rect(10, 65, 130, 45), "Login")) {
            Login ();
        }

        if (GUI.Button (new Rect(10, 120, 130, 45), "Create Chracter")) {
            CreateCharacter ();
        }

        if (GUI.Button (new Rect(10, 175, 130, 45), "Get Notice")) {
            GetNotice ();
        }

        if (GUI.Button (new Rect(10, 230, 130, 45), "Get Chracter")) {
            GetCharacter ();
        }

        if (GUI.Button (new Rect(10, 285, 130, 45), "Check GameVersion")) {
            CheckGameversion ();
        }

        if (GUI.Button (new Rect(10, 340, 130, 45), "Add Friend")) {
            AddFriend ();
        }

        if (GUI.Button (new Rect(10, 395, 130, 45), "Get Friends List")) {
            GetFriendsList ();
        }

        if (GUI.Button (new Rect(10, 450, 130, 45), "Find Friend By Nickname")) {
            FindFriendByNickname ();
        }

        if (GUI.Button (new Rect(10, 505, 130, 45), "Get Inventories")) {
            GetInventories ();
        }

        if (GUI.Button (new Rect(10, 560, 130, 45), "Set Inventories")) {
            SetInventories ();
        }

//        right side
        if (GUI.Button (new Rect(160, 10, 130, 45), "Get Slots")) {
            GetSlots ();
        }

        if (GUI.Button (new Rect(160, 65, 130, 45), "Set Slots")) {
            SetSlots ();
        }

        if (GUI.Button (new Rect(160, 120, 130, 45), "Get Stats")) {
            GetStats ();
        }

        if (GUI.Button (new Rect(160, 175, 130, 45), "Set Stats")) {
            SetStats ();
        }

        if (GUI.Button (new Rect(160, 230, 130, 45), "Write Mail")) {
            WriteMail ();
        }

        if (GUI.Button (new Rect(160, 285, 130, 45), "Read Mail")) {
            ReadMail ();
        }

        if (GUI.Button (new Rect(160, 340, 130, 45), "Get Gift Mail")) {
            GetGiftMail ();
        }

        if (GUI.Button (new Rect(160, 395, 130, 45), "Get Mail List")) {
            GetMailList ();
        }

        if (GUI.Button (new Rect(160, 450, 130, 45), "Delete Mails")) {
            DeleteMails ();
        }

    }

    void Register ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("nickname", "id");
        dict.Add ("password", "password");
        dict.Add ("name", "name");
        dict.Add ("email", "email");

        // mrdPrt.Connecting(dict, "register");
        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.register));
    }

    void Login ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("nickname", "id");
        dict.Add ("password", "password");

        // mrdPrt.Connecting(dict, "login");
        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.login));
    }

    void CreateCharacter ()
    {
        var character_dict = new Dictionary<string, object> ();
        character_dict.Add ("name", "aaa");
        character_dict.Add ("hair_style", "aaa");
        character_dict.Add ("body_type", "aaa");

        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);
        dict.Add ("character", character_dict);

        // mrdPrt.Connecting(dict, "create_character");
        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.create_character));
    }

    void GetNotice ()
    {
        var dict = new Dictionary<string, object> ();

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.get_notice));
    }

    void GetCharacter ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.get_character));
    }

    void CheckGameversion ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("game_version", "1.0.0");
        dict.Add ("os_type", "android");

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.check_gameversion));
    }

    void AddFriend ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);
        dict.Add ("friend_nickname", "id");

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.add_friend));
    }

    void GetFriendsList ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.get_friendslist));
    }

    void FindFriendByNickname ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);
        dict.Add ("friend_nickname", "id");

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.find_friendbynickname));
    }

    void GetInventories ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.get_inventories));
    }

    void SetInventories ()
    {
        var ivt_list = new List<Dictionary<string, object>> ();

        var got_item = new Dictionary<string, object> ();
        got_item.Add ("item_index", "AAA");
        got_item.Add ("item_count", 5);
        got_item.Add ("slot_no", 1);

        ivt_list.Add (got_item);

        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);
        dict.Add ("inventories", ivt_list);

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.set_inventories));
    }

    void GetSlots ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.get_slots));
    }

    void SetSlots ()
    {
        var ivt_list = new List<Dictionary<string, object>> ();

        var got_item = new Dictionary<string, object> ();
        got_item.Add ("slot_no", 0);
        got_item.Add ("item_index", "aaa");

        ivt_list.Add (got_item);

        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);
        dict.Add ("slots", ivt_list);

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.set_slots));
    }

    void GetStats ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.get_stats));
    }

    void SetStats ()
    {
        var stats = new Dictionary<string, object> ();
        stats.Add ("level", 1);
        stats.Add ("exp", 10);
        stats.Add ("hp", 10);
        stats.Add ("weapon_level", 10);
        stats.Add ("weapon_exp", 10);
        stats.Add ("visited_zone_no", 1);

        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);
        dict.Add ("stats", stats);

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.set_stats));
    }

    void WriteMail ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);
        dict.Add ("mail_to", "id");
        dict.Add ("content", "가나다라");

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.write_mail));
    }

    void ReadMail ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);
        dict.Add ("mail_index", 1);

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.read_mail));
    }

    void GetGiftMail ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);
        dict.Add ("mail_index", 1);

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.get_giftmail));
    }

    void GetMailList ()
    {
        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.get_maillist));
    }

    void DeleteMails ()
    {
        var tmp_mails = new List<int> ();
        tmp_mails.Add (1);
        tmp_mails.Add (2);

        var dict = new Dictionary<string, object> ();
        dict.Add ("session_id", mrdPrt.sessionId);
        dict.Add ("mail_indexes", tmp_mails);

        mrdPrt.Connecting (dict, Enum.GetName (typeof(ProtocolType), ProtocolType.delete_mails));
    }
}
