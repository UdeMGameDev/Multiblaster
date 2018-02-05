
use_bpm 120
#use_random_seed

live_loop :drums do
  
  sample :drum_bass_soft
  
  #Hi-hat ticks
  if one_in(2)
    sleep 0.5
    2.times do
      sample :drum_cymbal_closed, rate:1.70, amp:1
      sleep 0.5
    end
  else
    sleep 1.5
  end
  
  sample :drum_bass_soft if one_in(2)
  sleep 0.5
  sample :drum_snare_soft
  sleep 1
  sample :drum_bass_soft
  sleep 0.5
  sample :drum_bass_soft if one_in(3)
  sleep 1
  sample :drum_bass_soft
  sleep 0.5
  sample :drum_bass_soft
  sleep 1
  sample :drum_snare_soft
  sleep 2
end

live_loop :synth do
  
  use_synth :blade
  use_synth_defaults release:1.5
  if (ring false, false, false, true).tick(:variant)
    play :e3
    sleep 3
    play :d3
    sleep 2
    play (ring :c3, :c3, :a2).tick
    sleep 1.5
    play (ring :a2, :d3, :c3).tick
    sleep 1.5
    play (ring :c3, :a2).tick
    sleep 8
  else
    cue (:doTheThing) if (ring false, false ,false, true, false, false).tick(:thing)
    use_synth_defaults release:1
    play :e3, release: 1.5
    sleep 3
    play :g3, release: 1.5
    sleep 1.5
    play :e3, release: 1.5
    sleep 0.5
    play :g3
    sleep 1
    play :a3
    sleep 0.5
    play :e3
    sleep 0.5
    play :d3
    sleep 0.5
    play :d3
    sleep 0.5
    
    if (ring false,false,false,false,false,false,false,false,false,false,false,true).tick(:fancy)
      #play :e3
      sleep 0.5
      play :g3
      sleep 1
      play :e3
      sleep 0.5
      play :a3
      sleep 1
      play :e3
      sleep 0.5
      play :g3
      sleep 1
      play :b3
      sleep 0.5
      play :c4
      sleep 0.5
      play :b3, release:1.5
      sleep 1
      play :e3
      sleep 0.5
      play :g3
      sleep 1
      play :a3
    else
      sleep 8
    end
  end
end


live_loop :bass do
  use_synth :dpulse
  use_synth_defaults sustain:1, attack:0, amp:0.4, cutoff:60
  
  3.times do
    play :c2
    sleep 1
  end
  5.times do
    play :d2
    sleep 1
  end
  
  3.times do
    play :a1
    sleep 1
  end
  5.times do
    play :e2
    sleep 1
  end
end

live_loop :thingy do
  sync :doTheThing
  use_synth :blade
  use_synth_defaults amp:1.5
  2.times do
    play :c4, release:4
    sleep 3
    play :b3, release:4
    sleep 3
    play :e3, release:2
    sleep 1
    play :g3, release:8
    sleep 9
  end
end

