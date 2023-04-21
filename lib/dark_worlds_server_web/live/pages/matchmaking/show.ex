defmodule DarkWorldsServerWeb.MatchmakingLive.Show do
  alias DarkWorldsServer.Matchmaking
  use DarkWorldsServerWeb, :live_view
  # alias DarkWorldsServer.Matchmaking

  def mount(%{"session_id" => session_id}, _session, socket) do
    case connected?(socket) do
      false ->
        {:ok, assign(socket, session_id: session_id, player_count: 1)}

      true ->
        # TODO: Replace this by a proper player_id once we use actual accounts
        player_id = "player_id_#{:rand.uniform(1000)}"
        Phoenix.PubSub.subscribe(DarkWorldsServer.PubSub, Matchmaking.session_topic(session_id))
        Matchmaking.add_player(player_id, session_id)
        {:ok, assign(socket, session_id: session_id, player_id: player_id, player_count: 1)}
    end
  end

  def handle_info({:player_added, player_count}, socket) do
    {:noreply, assign(socket, :player_count, player_count)}
  end

  def handle_info({:player_removed, player_count}, socket) do
    {:noreply, assign(socket, :player_count, player_count)}
  end

  def handle_info({:ping, pid}, socket) do
    send(pid, :pong)
    {:noreply, socket}
  end

  def terminate(_reason, socket) do
    Matchmaking.remove_player(socket.assigns[:player_id], socket.assigns[:session_id])
    :ignored
  end
end