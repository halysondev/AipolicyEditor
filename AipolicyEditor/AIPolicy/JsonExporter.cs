using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AipolicyEditor.AIPolicy.Operations.CustomEditors;

namespace AipolicyEditor.AIPolicy
{
    public static class JsonExporter
    {
        public static void ExportPolicyToJson(CPolicyData policy, string filePath)
        {
            var policyJson = new JObject
            {
                ["ID"] = policy.ID,
                ["Version"] = policy.Version,
                ["Triggers"] = JArray.FromObject(policy.Triggers.Select(trigger => ConvertTriggerToJson(trigger)))
            };

            // Write to file with pretty formatting
            File.WriteAllText(filePath, policyJson.ToString(Formatting.Indented), Encoding.UTF8);
        }

        public static void ExportAllPoliciesToJson(AIFile aiFile, string outputDirectory)
        {
            // Create directory if it doesn't exist
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Export each policy to a separate JSON file
            foreach (var policy in aiFile.Controllers)
            {
                string fileName = $"{policy.ID}.json";
                string filePath = Path.Combine(outputDirectory, fileName);
                ExportPolicyToJson(policy, filePath);
            }
        }

        private static JObject ConvertTriggerToJson(CTriggerData trigger)
        {
            return new JObject
            {
                ["ID"] = trigger.ID,
                ["Version"] = trigger.Version,
                ["Name"] = trigger.Name,
                ["Active"] = trigger.Active,
                ["Run"] = trigger.Run,
                ["AttackValid"] = trigger.AttackValid,
                ["RootCondition"] = ConvertConditionToJson(trigger.RootConditon),
                ["Operations"] = JArray.FromObject(trigger.Operations.Select(op => ConvertOperationToJson(op)))
            };
        }

        private static JObject ConvertConditionToJson(Condition condition)
        {
            if (condition == null)
                return null;

            var conditionJson = new JObject
            {
                ["ID"] = condition.ID,
                ["Type"] = condition.Type,
                ["TypeName"] = Conditions.Conditions.GetName(condition.ID),
                ["Value"] = JArray.FromObject(condition.Value ?? new object[0]),
                ["SubNodeL"] = condition.SubNodeL,
                ["SubNodeR"] = condition.SubNodeR
            };

            if (condition.ConditionLeft != null)
            {
                conditionJson["ConditionLeft"] = ConvertConditionToJson(condition.ConditionLeft);
            }

            if (condition.ConditionRight != null)
            {
                conditionJson["ConditionRight"] = ConvertConditionToJson(condition.ConditionRight);
            }

            return conditionJson;
        }

        private static JObject ConvertOperationToJson(IOperation operation)
        {
            var operationJson = new JObject
            {
                ["OperID"] = operation.OperID,
                ["Name"] = operation.Name,
                ["FromVersion"] = operation.FromVersion,
                ["Type"] = operation.GetType().Name
            };

            // Use reflection to get all public properties
            var properties = operation.GetType().GetProperties()
                .Where(p => p.CanRead && 
                       p.Name != "OperID" && 
                       p.Name != "Name" && 
                       p.Name != "FromVersion" &&
                       !p.GetCustomAttributes(typeof(System.ComponentModel.BrowsableAttribute), false)
                           .Cast<System.ComponentModel.BrowsableAttribute>()
                           .Any(a => !a.Browsable));

            foreach (var prop in properties)
            {
                try
                {
                    var value = prop.GetValue(operation);
                    if (value != null)
                    {
                        // Handle special types
                        if (value is TargetParam targetParam)
                        {
                            operationJson[prop.Name] = ConvertTargetParamToJson(targetParam);
                        }
                        else if (value is Enum)
                        {
                            operationJson[prop.Name] = new JObject
                            {
                                ["Value"] = Convert.ToInt32(value),
                                ["Name"] = value.ToString()
                            };
                        }
                        else if (value.GetType().IsClass && value.GetType().Namespace?.StartsWith("AipolicyEditor") == true)
                        {
                            // Handle custom types from AipolicyEditor namespace
                            operationJson[prop.Name] = JObject.FromObject(value);
                        }
                        else
                        {
                            operationJson[prop.Name] = JToken.FromObject(value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle exception if needed
                    operationJson[prop.Name] = $"Error: {ex.Message}";
                }
            }

            return operationJson;
        }

        private static JObject ConvertTargetParamToJson(TargetParam targetParam)
        {
            return new JObject
            {
                ["Target"] = new JObject
                {
                    ["Value"] = (int)targetParam.Target,
                    ["Name"] = targetParam.Target.ToString()
                },
                ["Occupations"] = targetParam.Occupations,
                ["Players"] = targetParam.Players,
                ["Unk2"] = targetParam.Unk2,
                ["Unk3"] = targetParam.Unk3,
                ["Unk4"] = targetParam.Unk4
            };
        }

        public static void ExportSelectedPoliciesToJson(IEnumerable<CPolicyData> policies, string outputDirectory)
        {
            // Create directory if it doesn't exist
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Export each selected policy to a separate JSON file
            foreach (var policy in policies)
            {
                string fileName = $"{policy.ID}.json";
                string filePath = Path.Combine(outputDirectory, fileName);
                ExportPolicyToJson(policy, filePath);
            }
        }
    }
} 