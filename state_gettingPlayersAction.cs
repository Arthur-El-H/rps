using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_gettingPlayersAction: IState
{
    State_gettingPlayersTurn _stateInWhichTurnIsBuild;
    actionBase _action;
    statemachine _statemachine;
    Player _player;
    public Queue<actionBase> _queueToAddActionTo;     

    public State_gettingPlayersAction(statemachine statemachine, Player player, Queue<actionBase> queueToAddActionTo = null)
    {
        _statemachine = statemachine;
        if (queueToAddActionTo == null)
        {
            _queueToAddActionTo = new Queue<actionBase>();
        }
        else
        {
            _queueToAddActionTo = queueToAddActionTo;
        }
        _player = player;
    }

    public void Enter()
    {
        castAction();
    }

    public void Execute()
    {
        //At the end:
        _queueToAddActionTo.Enqueue(_action);
        State_gettingPlayersTurn nextState = new State_gettingPlayersTurn(_statemachine, _player, _queueToAddActionTo);
        _statemachine.changeState(_stateInWhichTurnIsBuild);
    }

    public void Exit()
    {
    }

    public void handleInput(IInput input)
    {
        throw new System.NotImplementedException();
    }
    private void castAction()
    {
        throw new NotImplementedException();
    }
}