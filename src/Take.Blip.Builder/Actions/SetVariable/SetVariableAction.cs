﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Take.Blip.Builder.Actions.SetVariable
{
    public class SetVariableAction : ActionBase<SetVariableActionSettings>
    {
        public SetVariableAction()
            : base(nameof(SetVariable))
        {
            
        }

        public override Task ExecuteAsync(IContext context, SetVariableActionSettings settings, CancellationToken cancellationToken)
        {
            var expiration = default(TimeSpan);
            if (settings.Expiration.HasValue)
            {
                expiration = TimeSpan.FromSeconds(settings.Expiration.Value);
            }

            return context.SetVariableAsync(settings.Variable, settings.Value, cancellationToken, expiration);
        }
    }
}
