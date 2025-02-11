// <copyright file="ConsoleExporter.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace OpenTelemetry.Exporter
{
    public abstract class ConsoleExporter<T> : BaseExporter<T>
        where T : class
    {
        private readonly ConsoleExporterOptions options;

        protected ConsoleExporter(ConsoleExporterOptions options)
        {
            this.options = options ?? new ConsoleExporterOptions();
            ConsoleTagTransformer.LogUnsupportedAttributeType = (string tagValueType, string tagKey) =>
            {
                this.WriteLine($"Unsupported attribute type {tagValueType} for {tagKey}.");
            };
        }

        protected void WriteLine(string message)
        {
            if (this.options.Targets.HasFlag(ConsoleExporterOutputTargets.Console))
            {
                Console.WriteLine(message);
            }

            if (this.options.Targets.HasFlag(ConsoleExporterOutputTargets.Debug))
            {
                System.Diagnostics.Trace.WriteLine(message);
            }
        }
    }
}
