using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public enum ProtocolType
{
		register = 100
,
		login
,
		create_character
,
		get_notice
,
		get_character
,
		check_gameversion
,
		add_friend
,
		get_friendslist
,
		find_friendbynickname
,
		get_inventories
,
		set_inventories
,
		get_slots
,
		set_slots
,
		get_stats
,
		set_stats
,
		write_mail
,
		read_mail
,
		get_giftmail
,
		get_maillist
,
		delete_mails
,
		set_owncostumes
,
		get_owncostumes
,
		set_owncostumebases
,
		get_owncostumebases
,
}
;

public enum ResultCode
{
		Success = 100
,
		NicknameExist
,
		NicknameNonExist
,
		UserPasswordWrong
,
		InputParamError
,
		SessionIdNonExist
,
		SessionIdExpired
,
		NoData
,
		GameVersionError
,
		DBInputError
,
		AccessError = 200
,
}

public class MrdPrt : MonoBehaviour
{
		private string url = "http://127.0.0.1:5000";
		public string sessionId = "";
	// Use this for initialization
		void Start ()
		{

		}
	// Update is called once per frame
		void Update ()
		{

		}

		public void Connecting (Dictionary<string, object> dict, string prt_type)
		{
				var jsonString = Json.Serialize (dict);
				StartCoroutine (GoConnect(jsonString, prt_type));
		}

		IEnumerator GoConnect (string jsonString, string request_type)
		{
				var form = new WWWForm ();
				form.AddField ("data", jsonString);
				WWW www = new WWW (url+ "/" + request_type, form);
				yield return www;
				if (!String.IsNullOrEmpty (www.error)) {
						ErrorCommand ();
				} else {
						Debug.Log (www.text);
						IDictionary search = (IDictionary)Json.Deserialize (www.text);
						Debug.Log (search["result"]);
						this.GotData (www.text);
				}
		}

		void ErrorCommand ()
		{
				Debug.Log ("Network Error");
		}

		public void GotData (string jsonString)
		{
				if (jsonString != "") {
						IDictionary search = (IDictionary)Json.Deserialize (jsonString);
						string str_out = "";
						switch ((ProtocolType)int.Parse (search["type"].ToString())) {
						case ProtocolType.register:
								str_out = "RegisterUser";
								Debug.Log (str_out);

								this.RegisterCommand (search, str_out);

								break;

						case ProtocolType.login:
								str_out = "LoginUser";
								Debug.Log (str_out);

								this.LoginCommand (search, str_out);

								break;

						case ProtocolType.create_character:
								str_out = "CreateCharacter";
								Debug.Log (str_out);

								this.CreateCharacterCommand (search, str_out);

								break;

						case ProtocolType.get_notice:
								str_out = "GetNotice";
								Debug.Log (str_out);

								this.GetNoticeCommand (search, str_out);

								break;

						case ProtocolType.get_character:
								str_out = "GetCharacter";
								Debug.Log (str_out);

								this.GetCharacterCommand (search, str_out);

								break;

						case ProtocolType.check_gameversion:
								str_out = "CheckGameversion";
								Debug.Log (str_out);

								this.CheckGameversionCommand (search, str_out);

								break;

						case ProtocolType.add_friend:
								str_out = "AddFriend";
								Debug.Log (str_out);

								this.AddFriendCommand (search, str_out);

								break;

						case ProtocolType.get_friendslist:
								str_out = "GetFriendsList";
								Debug.Log (str_out);

								this.GetFriendsListCommand (search, str_out);

								break;

						case ProtocolType.find_friendbynickname:
								str_out = "FindFriendByNickname";
								Debug.Log (str_out);

								this.FindFriendByNicknameCommand (search, str_out);

								break;

						case ProtocolType.get_inventories:
								str_out = "GetInventories";
								Debug.Log (str_out);

								this.GetInventoriesCommand (search, str_out);

								break;

						case ProtocolType.set_inventories:
								str_out = "SetInventories";
								Debug.Log (str_out);

								this.SetInventoriesCommand (search, str_out);

								break;

						case ProtocolType.get_slots:
								str_out = "GetSlots";
								Debug.Log (str_out);

								this.GetSlotsCommand (search, str_out);
								break;

						case ProtocolType.set_slots:
								str_out = "SetSlots";
								Debug.Log (str_out);

								this.SetSlotsCommand (search, str_out);
								break;

						case ProtocolType.get_stats:
								str_out = "GetStats";
								Debug.Log (str_out);

								this.GetStatsCommand (search, str_out);
								break;

						case ProtocolType.set_stats:
								str_out = "SetStats";
								Debug.Log (str_out);

								this.SetStatsCommand (search, str_out);
								break;

						case ProtocolType.write_mail:
								str_out = "WriteMail";
								Debug.Log (str_out);

								this.WriteMailCommand (search, str_out);
								break;

						case ProtocolType.read_mail:
								str_out = "ReadMail";
								Debug.Log (str_out);

								this.ReadMailCommand (search, str_out);
								break;

						case ProtocolType.get_giftmail:
								str_out = "GetGiftMail";
								Debug.Log (str_out);

								this.GetGiftMailCommand (search, str_out);
								break;

						case ProtocolType.get_maillist:
								str_out = "GetMailList";
								Debug.Log (str_out);

								this.GetMailListCommand (search, str_out);
								break;

						case ProtocolType.delete_mails:
								str_out = "DeleteMails";
								Debug.Log (str_out);

								this.DeleteMailsCommand (search, str_out);
								break;

						case ProtocolType.set_owncostumes:
								str_out = "SetOwnCostumes";
								Debug.Log (str_out);

								this.SetOwnCostumesCommand (search, str_out);
								break;

						case ProtocolType.get_owncostumes:
								str_out = "GetOwnCostumes";
								Debug.Log (str_out);

								this.GetOwnCostumesCommand (search, str_out);
								break;

						case ProtocolType.set_owncostumebases:
								str_out = "SetOwnCostumeBases";
								Debug.Log (str_out);

								this.SetOwnCostumeBasesCommand (search, str_out);
								break;

						case ProtocolType.get_owncostumebases:
								str_out = "GetOwnCostumeBases";
								Debug.Log (str_out);

								this.GetOwnCostumeBasesCommand (search, str_out);
								break;

						default:
								break;
						}
				}
		}

		public void RegisterCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NicknameExist:
						Debug.Log (str_out + " NicknameExist");
						break;
				case ResultCode.InputParamError:
						Debug.Log (str_out + " InputParamError");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		public void LoginCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						this.sessionId = got_data ["session_id"].ToString ();
						Debug.Log ("Session Id: " + this.sessionId);
						break;
				case ResultCode.NicknameNonExist:
						Debug.Log (str_out + " NicknameNonExist");
						break;
				case ResultCode.UserPasswordWrong:
						Debug.Log (str_out + " UserPasswordWrong");
						break;
				case ResultCode.InputParamError:
						Debug.Log (str_out + " InputParamError");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		public void CreateCharacterCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.InputParamError:
						Debug.Log (str_out + " InputParamError");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		public void GetNoticeCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		public void GetCharacterCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				case ResultCode.SessionIdNonExist:
						Debug.Log (str_out + " SessionIdNonExist");
						break;
				case ResultCode.SessionIdExpired:
						Debug.Log (str_out + " SessionIdExpired");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		public void CheckGameversionCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.InputParamError:
						Debug.Log (str_out + " InputParamError");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				case ResultCode.GameVersionError:
						Debug.Log (str_out + " GameVersionError");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		public void AddFriendCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		public void GetFriendsListCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		public void FindFriendByNicknameCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void GetInventoriesCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void SetInventoriesCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void GetSlotsCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void SetSlotsCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void GetStatsCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void SetStatsCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void WriteMailCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				case ResultCode.DBInputError:
						Debug.Log (str_out + " DBInputError");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void ReadMailCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						Debug.Log ("title: " + got_data["title"].ToString());
						Debug.Log ("content: " + got_data["content"].ToString());
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void GetGiftMailCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void GetMailListCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void DeleteMailsCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void SetOwnCostumesCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void GetOwnCostumesCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void SetOwnCostumeBasesCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}

		void GetOwnCostumeBasesCommand (IDictionary got_data, string str_command)
		{
				string str_out = str_command;
				int result_code_num = int.Parse (got_data["result"].ToString());

				switch ((ResultCode)result_code_num) {
				case ResultCode.Success:
						Debug.Log (str_out + " OK");
						break;
				case ResultCode.NoData:
						Debug.Log (str_out + " NoData");
						break;
				default:
						Debug.Log (str_out + " Error");
						break;
				}
		}
}
