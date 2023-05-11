defmodule DarkWorldsServerWeb.LobbyController do
  use DarkWorldsServerWeb, :controller

  alias DarkWorldsServer.Matchmaking
  alias DarkWorldsServer.Matchmaking.MatchingSupervisor
  alias DarkWorldsServer.Communication

  def new(conn, _params) do
    matchmaking_session_pid = Matchmaking.create_session()

    headers = Enum.into(conn.req_headers, %{})
    lobby_id = Communication.pid_to_external_id(matchmaking_session_pid)

    json(conn, %{lobby_id: lobby_id})
  end

  def current_lobbies(conn, _params) do
    headers = Enum.into(conn.req_headers, %{})
    matchmaking_pids = MatchingSupervisor.children_pids()
    lobbies = Enum.map(matchmaking_pids, fn pid -> Communication.pid_to_external_id(pid) end)

    json(conn, %{lobbies: lobbies})
  end
end
