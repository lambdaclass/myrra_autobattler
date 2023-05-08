defmodule DarkWorldsServer.Matchmaking do
  @moduledoc """
  The Matchmaking context
  """

  alias DarkWorldsServer.Matchmaking.MatchingSession
  alias DarkWorldsServer.Matchmaking.MatchingSupervisor

  def create_session() do
    {:ok, pid} = MatchingSupervisor.start_child()
    pid
  end

  def add_player(player_id, session_pid) do
    MatchingSession.add_player(player_id, session_pid)
  end

  def remove_player(player_id, session_pid) do
    MatchingSession.remove_player(player_id, session_pid)
  end

  def fetch_sessions() do
    MatchingSupervisor.children_pids()
  end

  def session_topic(session_id) do
    "matching_session_#{session_id}"
  end

  def start_game(session_pid) do
    MatchingSession.start_game(session_pid)
  end
end